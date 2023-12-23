using System;
using System.Collections.Generic;
using System.Linq;
namespace BubberDinner.Contract.Authentication.Request;

public record LoginRequest
(
    string Email,
    string Password
);
