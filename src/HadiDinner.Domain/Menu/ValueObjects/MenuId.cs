using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId() { }

    private MenuId(Guid menuId)
    {
        Value = menuId;
    }

    public static MenuId Create(Guid menuId)
    {
        return new(menuId);
    }

    public static MenuId Create(string menuId)
    {
        return new(Guid.Parse(menuId));
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
