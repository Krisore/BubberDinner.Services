using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.Models;
using BubberDinner.Domain.Models.Menu.ValueObjects;

namespace BubberDinner.Domain.Menu.Entities;

public class MenuItem : Entity<MenuItemId>
{

    public string Name { get; }
    public string Description { get; }

    public MenuItem(MenuItemId id, string name, string description)
    : base(id)
    {
        Name = name;
        Description = description;
    }
    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

}