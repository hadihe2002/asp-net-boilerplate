using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId() { }

    private DinnerId(Guid dinnerId)
    {
        Value = dinnerId;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
