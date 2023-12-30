using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Persistent;
using BubberDinner.Domain.Entities;
using BubberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BubberDinner.Application.Authentication.Commons.DTOs;

namespace BubberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;


public class RegisterCommandHandler :
IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
     RegisterCommand request,
     CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmailAsync(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return await Task.FromResult(
            new AuthenticationResult(user, token)
        );
    }

}
