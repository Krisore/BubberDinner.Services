
namespace BubberDinner.Domain.Models.MenuAggregate.ValueObjects;



public class MenuItemId : ValueObject
{
    public Guid Value { get; }
    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }
}