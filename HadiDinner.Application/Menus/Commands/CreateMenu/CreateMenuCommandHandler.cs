using ErrorOr;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.Entities;
using MediatR;

namespace HadiDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(
        CreateMenuCommand request,
        CancellationToken cancellationToken
    )
    {
        ErrorOr<Menu> menuResult = Menu.Create(
            request.Name,
            request.Description,
            HostId.Create(request.HostId)
        );

        if (menuResult.IsError)
            return menuResult.Errors;
        Menu menu = menuResult.Value;

        var menuSections = request.Sections.ConvertAll(section =>
        {
            MenuSection menuSection = MenuSection.Create(
                name: section.Name,
                description: section.Description
            );
            List<MenuItem> sectionItems = section.Items.ConvertAll(
                item => MenuItem.Create(name: item.Name, description: item.Description)
            );
            menuSection.AddItems(sectionItems);

            return menuSection;
        });
        menu.AddSections(menuSections);

        _menuRepository.Add(menu);

        return menu;
    }
}
