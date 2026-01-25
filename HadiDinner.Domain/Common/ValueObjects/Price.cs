using ErrorOr;
using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public double Amount { get; }
    public string Currency { get; }

    private Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static ErrorOr<Price> Create(double amount, string currency)
    {
        if (amount < 0)
        {
            return Errors.Errors.Price.InvalidAmount;
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            return Errors.Errors.Price.InvalidCurrency;
        }

        return new Price(amount, currency.ToUpper());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
