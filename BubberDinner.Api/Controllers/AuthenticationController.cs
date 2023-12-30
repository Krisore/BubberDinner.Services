using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Commons.DTOs;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BubberDinner.Domain.Common.Errors.Errors;

namespace BubberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiBaseController
{
    private readonly ISender _sender;
    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = new RegisterCommand
        (
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var response = await _sender.Send(command);
        return response.Match(
            response => Ok(MapAuthResult(response)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery
        (
            request.Email,
            request.Password
        );
        var response = await _sender.Send(query);
        if (response.IsError && response.FirstError == Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Invalid credentials"
            );
        }
        return response.Match(
            response => Ok(MapAuthResult(response)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult command)
    {
        return new AuthenticationResponse
        (
            command.User.Id,
            command.User.FirstName,
            command.User.LastName,
            command.User.Email,
            command.Token
        );
    }

}
