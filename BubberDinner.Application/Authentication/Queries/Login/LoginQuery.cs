using BubberDinner.Application.Common.Interface.Authentication;
using BubberDinner.Application.Common.Interface.Persistent;
using BubberDinner.Domain.Entities;
using BubberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BubberDinner.Application.Authentication.Commons.DTOs;

namespace BubberDinner.Application.Authentication.Queries.Login;


public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;


public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmailAsync(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return await Task.FromResult(new AuthenticationResult(user, token));
    }
}
