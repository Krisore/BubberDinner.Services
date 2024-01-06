using System.Data;
using FluentValidation;

namespace BubberDinner.Application.Menus.Commands.CreateMenu;



public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
        RuleFor(x => x.HostId).Must(x => x.Length == 36).WithMessage("HostId must be a valid");
        RuleFor(x => x.Sections).NotEmpty();
    }
}
