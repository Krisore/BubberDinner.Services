using BubberDinner.Application.Authentication;
using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;


[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var command = _authenticationService.Register
        (
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse
        (
            command.Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var command = _authenticationService.Login
        (
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse
        (
            command.Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Token
        );
        return Ok(response);
    }
}
