using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }
    public DinnerId(Guid value)
    {
        Value = value;
    }
    public DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}