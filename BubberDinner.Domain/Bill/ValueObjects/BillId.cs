using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Bill.ValueObjects;


public class BillId : ValueObject
{
    public Guid Value { get; }

    public BillId(Guid value)
    {
        Value = value;
    }
    public static BillId CreateUnique() => new BillId(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}