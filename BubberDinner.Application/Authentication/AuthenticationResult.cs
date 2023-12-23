using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Authentication
{
    /// <summary>
    /// This is a authentication result to give a response for a request.
    /// </summary>
    /// <param name="Id"> An Unique Identifier for User</param>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Token"></param>
    public record AuthenticationResult
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
