using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Persistent;
using BubberDinner.Application.Common.Interface.Services;
using BubberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //!Important: check if user already exist
        if (_userRepository.GetUserByEmailAsync(email) is not null)
        {
            throw new Exception("User already Exists, Error Occured");
        }
        //?INFO: create user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
        };
        _userRepository.Add(user);
        //?Generate a token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        //TODO: validate the user exists
        if (_userRepository.GetUserByEmailAsync(email) is not User user)
        {
            throw new Exception("User not found");
        }
        //TODO: Validate the password is correct 
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }
        //TODO: Create Jwt Token.
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}
