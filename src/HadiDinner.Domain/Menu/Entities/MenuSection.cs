using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Menu.ValueObjects;

namespace HadiDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection() { }

    private MenuSection(MenuSectionId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }

    public void AddItems(List<MenuItem> items)
    {
        _items.AddRange(items);
    }

    public void AddItem(MenuItem item)
    {
        _items.Add(item);
    }
}
