using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId() { }

    private UserId(Guid userId)
    {
        Value = userId;
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }

    public static UserId Create(string value)
    {
        return new(Guid.Parse(value));
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
