using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    public byte Value { get; }

    private Rating(byte value)
    {
        Value = value;
    }

    public static Rating Create(byte value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
