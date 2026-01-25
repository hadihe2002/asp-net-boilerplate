using ErrorOr;

namespace HadiDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Price
    {
        public static Error InvalidAmount =>
            Error.Validation("Price.InvalidAmount", "The amount of price should be positive");

        public static Error InvalidCurrency =>
            Error.Validation("Price.InvalidCurrency", "The currency is not valid");
    }
}
