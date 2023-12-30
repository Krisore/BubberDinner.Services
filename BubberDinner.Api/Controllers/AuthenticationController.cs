using BubberDinner.Application.Authentication;
using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using static BubberDinner.Domain.Common.Errors.Errors;

namespace BubberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiBaseController
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> command = _authenticationService.Register
        (
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        return command.Match(
            command => Ok(MapAuthResult(command)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> command = _authenticationService.Login
        (
            request.Email,
            request.Password
        );

        if (command.IsError && command.FirstError == Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Invalid credentials"
            );
        }
        return command.Match(
            command => Ok(MapAuthResult(command)),
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
