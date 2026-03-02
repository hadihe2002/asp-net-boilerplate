using FluentAssertions;
using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.Entities;

namespace HadiDinner.Application.UnitTests.Menus;

public static class MenuExtensions
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand createMenuCommand)
    {
        menu.Id.Should().NotBeNull();
        menu.Name.Should().Be(createMenuCommand.Name);
        menu.Description.Should().Be(createMenuCommand.Description);
        menu.Sections.Should().HaveSameCount(createMenuCommand.Sections);
        menu.Sections.Zip(createMenuCommand.Sections)
            .ToList()
            .ForEach(pair => ValidateSection(pair.First, pair.Second));

        static void ValidateSection(MenuSection menuSection, MenuSectionCommand menuSectionCommand)
        {
            menuSection.Id.Should().NotBeNull();
            menuSection.Name.Should().Be(menuSectionCommand.Name);
            menuSection.Description.Should().Be(menuSectionCommand.Description);
            menuSection.Items.Should().HaveSameCount(menuSectionCommand.Items);
            menuSection
                .Items.Zip(menuSectionCommand.Items)
                .ToList()
                .ForEach(pair => ValidateItem(pair.First, pair.Second));
        }

        static void ValidateItem(MenuItem menuItem, MenuItemCommand menuItemCommand)
        {
            menuItem.Id.Should().NotBeNull();
            menuItem.Name.Should().Be(menuItemCommand.Name);
            menuItem.Description.Should().Be(menuItemCommand.Description);
        }
    }
}
