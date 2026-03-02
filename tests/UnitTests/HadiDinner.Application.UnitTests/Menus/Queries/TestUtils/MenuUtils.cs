using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.Entities;
using HadiDinner.Domain.Menu.ValueObjects;

namespace HadiDinner.Api.UnitTests.Menus.s.TestUtils;

public class CreateMenuUtils
{
    private MenuId _id = MenuId.CreateUnique();
    private HostId _hostId = HostId.CreateUnique();
    private string _name = "Menu Name";
    private string _description = "Menu Description";
    private List<MenuItem> _items =
    [
        MenuItem.Create("Menu Item Name 1", "Menu Item Description 1")
    ];
    private List<MenuSection> _sections =
    [
        MenuSection.Create("Menu Section Name 1", "Menu Section Description 1")
    ];

    public CreateMenuUtils()
    {
        _sections[0].AddItems(_items);
    }

    public CreateMenuUtils WithMenuSections(List<MenuSection> sections)
    {
        _sections = sections;
        return this;
    }

    public CreateMenuUtils WithHostId(HostId hostId)
    {
        _hostId = hostId;
        return this;
    }

    public CreateMenuUtils WithHostId(Guid hostId)
    {
        _hostId = HostId.Create(hostId);
        return this;
    }

    public CreateMenuUtils WithHostId(string hostId)
    {
        if (string.IsNullOrWhiteSpace(hostId))
            return this;
        _hostId = HostId.Create(hostId);
        return this;
    }

    public CreateMenuUtils WithMenuSections(int sectionCount = 1)
    {
        _sections.Clear();
        var sections = Enumerable
            .Range(0, sectionCount)
            .Select(index =>
            {
                var section = MenuSection.Create(
                    $"Menu Section {index}",
                    $"Menu Section Description {index}"
                );
                section.AddItems(_items);
                return section;
            });

        _sections.AddRange(sections);

        return this;
    }

    public CreateMenuUtils WithMenuItems(int itemCount = 1)
    {
        _items.Clear();
        var items = Enumerable
            .Range(0, itemCount)
            .Select(
                index => MenuItem.Create($"Menu Item {index}", $"Menu Item Description {index}")
            );
        _items.AddRange(items);

        return this;
    }

    public Menu CreateMenu()
    {
        var sections = _sections
            .Select(s =>
            {
                s.AddItems(_items);
                return s;
            })
            .ToList();
        Menu menu = Menu.Create(_name, _description, _hostId).Value;
        menu.AddSections(_sections);
        return menu;
    }
}
