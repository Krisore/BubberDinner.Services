using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}