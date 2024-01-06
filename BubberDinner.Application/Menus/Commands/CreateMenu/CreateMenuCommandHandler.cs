using System.Linq;

using BubberDinner.Application.Common.Interface.Menus;
using BubberDinner.Domain.HostAggregate;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.Models.MenuAggregate;

using ErrorOr;

using MediatR;
namespace BubberDinner.Application.Menus.Commands.CreateMenu;



public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //create menu
        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.CreateUnique(request.HostId),
            sections: request.Sections.ConvertAll(
            section => MenuSection.Create(section.Name, section.Description,
                        section.Items.ConvertAll(
                        item => MenuItem.Create(
                        item.Name,
                        item.Description))
                        )
                    )
                );
        //persist menu
        _menuRepository.CreateMenu(menu);
        //return menu
        if (menu is null)
        {
            return Error.NotFound("Menu not found");
        }
        return menu;
    }
}
