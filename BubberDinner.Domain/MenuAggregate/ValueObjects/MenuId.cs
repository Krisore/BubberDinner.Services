using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuAggregate.ValueObjects;


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

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
}