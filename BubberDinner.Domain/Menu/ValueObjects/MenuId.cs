using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Menu.ValueObjects;


public sealed class MenuId : ValueObject
{
    public Guid Value { get; }
    public MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}