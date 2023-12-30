using System.Data;
using BubberDinner.Application.Authentication.Commands.Register;
using FluentValidation;

namespace BubberDinner.Application.Authentication.Validators;


public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Password).Length(8, 100);
        RuleFor(x => x.Email).EmailAddress();
    }
}