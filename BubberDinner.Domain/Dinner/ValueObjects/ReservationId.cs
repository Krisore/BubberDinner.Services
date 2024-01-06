using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Dinner.ValueObjects;


public class ReservationId : ValueObject
{
    public ReservationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static ReservationId CreateUnique() => new ReservationId(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}