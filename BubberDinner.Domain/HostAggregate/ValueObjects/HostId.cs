
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.HostAggregate.ValueObjects;


public class HostId : ValueObject
{
    public Guid Value { get; }
    public HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique(string value = "")
    {
        if (string.IsNullOrEmpty(value))
        {
            var hostId = Guid.Parse(value.ToString());
            return new HostId(hostId);
        }
        return new HostId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}