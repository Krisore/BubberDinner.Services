using BubberDinner.Application.Common.Interface.Menus;
using BubberDinner.Domain.Models.MenuAggregate;

namespace BubberDinner.Infrastructure.Persistent.Repositories;

public class MenuRespository(ApplicationDbContext applicationDbContext) : IMenuRepository
{
    public static readonly List<Menu> Menus = new();
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public void CreateMenu(Menu menu)
    {
        _applicationDbContext.Add(menu);
        _applicationDbContext.SaveChanges();
    }
}
