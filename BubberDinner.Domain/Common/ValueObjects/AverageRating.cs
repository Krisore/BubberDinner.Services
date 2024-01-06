using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.ValueObjects;


public sealed class AverageRating : ValueObject
{
    public AverageRating(double value, int numberRatings)
    {
        Value = value;
        NumberRatings = numberRatings;
    }
    public double Value { get; private set; }
    public int NumberRatings { get; private set; }

    public static AverageRating CreateNew(double rating = 0, int numberRatings = 0)
    {
        return new AverageRating(rating, numberRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumberRatings) + rating.Value) / ++NumberRatings;
    }
    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumberRatings) + rating.Value) / --NumberRatings;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumberRatings;
    }
}