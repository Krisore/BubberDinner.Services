using BubberDinner.Contract.Authentication.Request;
using BubberDinner.Contract.Authentication.Response;

namespace BubberDinner.Application.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
        AuthenticationResult Login(string email, string password);
    }
}
