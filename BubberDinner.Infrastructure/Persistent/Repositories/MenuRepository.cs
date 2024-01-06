using BubberDinner.Application.Common.Interface.Menus;
using BubberDinner.Domain.Models.MenuAggregate;

namespace BubberDinner.Infrastructure.Persistent.Repositories;

public class MenuRespository : IMenuRepository
{
    public static readonly List<Menu> Menus = new();
    public void CreateMenu(Menu menu)
    {
        Menus.Add(menu);
    }
}
