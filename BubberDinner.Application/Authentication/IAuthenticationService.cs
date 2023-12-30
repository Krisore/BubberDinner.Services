using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;
using ErrorOr;

namespace BubberDinner.Application.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
