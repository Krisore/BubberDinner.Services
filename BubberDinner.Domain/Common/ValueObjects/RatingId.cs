using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.ValueObjects
{
    public class RatingId : ValueObject
    {

        public Guid Value { get; }
        public RatingId(Guid value)
        {
            Value = value;
        }
        public static RatingId CreateUnique() => new RatingId(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}