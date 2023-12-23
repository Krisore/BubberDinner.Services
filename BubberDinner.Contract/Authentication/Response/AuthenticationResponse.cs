using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Contract.Authentication.Response
{
    public record AuthenticationResponse
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
