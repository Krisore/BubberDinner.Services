using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IDateTimeProvider dateTimeProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //TODO: check if user already exist
        //TODO: create user
        //TODO: create JWT Token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "last name", "your last name", email, password);
    }
}
