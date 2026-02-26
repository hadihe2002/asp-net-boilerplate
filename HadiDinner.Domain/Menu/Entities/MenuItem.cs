using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Menu.ValueObjects;

namespace HadiDinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    private MenuItem() { }

    private MenuItem(MenuItemId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
