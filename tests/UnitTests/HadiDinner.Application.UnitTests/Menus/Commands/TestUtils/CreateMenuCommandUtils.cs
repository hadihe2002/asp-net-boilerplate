using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Domain.Host.ValueObjects;

namespace HadiDinner.Api.UnitTests.Menus.Commands.TestUtils;

public class CreateMenuCommandUtils
{
    private HostId _hostId = HostId.Create(Guid.NewGuid());
    private string _name = "Menu Name";
    private string _description = "Menu Description";
    private List<MenuItemCommand> _items =
    [
        new MenuItemCommand("Menu Item Name 1", "Menu Item Description 1")
    ];
    private List<MenuSectionCommand> _sections =
    [
        new MenuSectionCommand(
            "Menu Section Name 1",
            "Menu Section Description 1",
            [new MenuItemCommand("Menu Item Name 1", "Menu Item Description 1")]
        )
    ];

    public CreateMenuCommandUtils WithMenuSectionCommands(List<MenuSectionCommand> sectionCommands)
    {
        _sections = sectionCommands;
        return this;
    }

    public CreateMenuCommandUtils WithHostId(HostId hostId)
    {
        _hostId = hostId;
        return this;
    }

    public CreateMenuCommandUtils WithHostId(Guid hostId)
    {
        _hostId = HostId.Create(hostId);
        return this;
    }

    public CreateMenuCommandUtils WithHostId(string hostId)
    {
        if (string.IsNullOrWhiteSpace(hostId))
            return this;
        _hostId = HostId.Create(hostId);
        return this;
    }

    public CreateMenuCommandUtils WithMenuSectionCommands(int sectionCount = 1)
    {
        _sections.Clear();
        var sections = Enumerable
            .Range(0, sectionCount)
            .Select(
                index =>
                    new MenuSectionCommand(
                        $"Menu Section {index}",
                        $"Menu Section Description {index}",
                        _items
                    )
            );

        _sections.AddRange(sections);

        return this;
    }

    public CreateMenuCommandUtils WithMenuItemCommands(int itemCount = 1)
    {
        _items.Clear();
        var items = Enumerable
            .Range(0, itemCount)
            .Select(
                index => new MenuItemCommand($"Menu Item {index}", $"Menu Item Description {index}")
            );
        _items.AddRange(items);

        return this;
    }

    public CreateMenuCommand CreateMenuCommand()
    {
        return new CreateMenuCommand(_hostId.Value.ToString(), _name, _description, _sections);
    }
}
