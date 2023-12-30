using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BubberDinner.Domain.Common.Errors.Errors;

namespace BubberDinner.Api.Controllers;


[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiBaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = _mapper.Map<RegisterCommand>(request);
        var response = await _sender.Send(command);
        return response.Match(
            response => Ok(_mapper.Map<AuthenticationResponse>(response)),
            errors => Problem(errors)
        );
    }


    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var response = await _sender.Send(query);
        if (response.IsError && response.FirstError == Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Invalid credentials"
            );
        }
        return response.Match(
            response => Ok(_mapper.Map<AuthenticationResponse>(response)),
            errors => Problem(errors)
        );
    }

}
