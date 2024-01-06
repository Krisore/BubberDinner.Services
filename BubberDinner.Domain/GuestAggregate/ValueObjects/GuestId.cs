using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.GuestAggregate.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; }
    public GuestId(Guid value)
    {
        Value = value;
    }
    public static GuestId CreateUnique() => new GuestId(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}