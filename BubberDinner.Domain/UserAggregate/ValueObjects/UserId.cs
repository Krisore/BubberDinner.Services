using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.UserAggregate.ValueObjects;


public class UserId : ValueObject
{
    public Guid Value { get; set; }
    public UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreatUnique() => new UserId(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}