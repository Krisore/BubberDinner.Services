using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.ValueObjects;
public class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Price Create(decimal amount = 0.00m, string currency = "PHP")
    => new Price(amount, currency);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}