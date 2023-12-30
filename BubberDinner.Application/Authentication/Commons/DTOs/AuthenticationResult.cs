using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Authentication.Commons.DTOs;
/// <summary>
/// This is a authentication result to give a response for a request.
/// </summary>
public record AuthenticationResult
(
    User User,
    string Token
);
