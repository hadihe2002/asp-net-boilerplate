using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid menuId)
    {
        Value = menuId;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
