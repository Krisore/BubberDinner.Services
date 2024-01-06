using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Host.ValueObjects;


public class HostId : ValueObject
{
    public Guid Value { get; }
    public HostId(Guid value)
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