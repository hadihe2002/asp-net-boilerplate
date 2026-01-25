using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid menuItemId)
    {
        Value = menuItemId;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
