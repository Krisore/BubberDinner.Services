using BubberDinner.Domain.Models.MenuAggregate;

namespace BubberDinner.Application.Common.Interface.Menus;

public interface IMenuRepository
{
    void CreateMenu(Menu menu);

}