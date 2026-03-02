using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Domain.Host.ValueObjects;

namespace HadiDinner.Api.UnitTests.Menus.Commands.TestUtils;

public class CreateMenuCommandUtils
{
    private static HostId _hostId = HostId.Create(Guid.NewGuid());
    private static string _name = "Menu Name";
    private static string _description = "Menu Description";
    private static List<MenuItemCommand> _items =
    [
        new MenuItemCommand("Menu Item Name", "Menu Item Description")
    ];
    private static List<MenuSectionCommand> _sections =
    [
        new MenuSectionCommand("Menu Section Name", "Menu Section Description", _items)
    ];

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

    public CreateMenuCommand Create()
    {
        return new CreateMenuCommand(_hostId.Value.ToString(), _name, _description, _sections);
    }
}
