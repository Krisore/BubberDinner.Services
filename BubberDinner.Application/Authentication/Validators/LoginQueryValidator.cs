using System.Data;
using BubberDinner.Application.Authentication.Queries.Login;
using FluentValidation;

namespace BubberDinner.Application.Authentication.Validators;


public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}