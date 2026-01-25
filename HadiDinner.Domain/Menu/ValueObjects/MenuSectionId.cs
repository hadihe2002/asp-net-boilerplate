using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid menuSectionId)
    {
        Value = menuSectionId;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
