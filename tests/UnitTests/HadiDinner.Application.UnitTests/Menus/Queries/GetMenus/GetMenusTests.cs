using FluentAssertions;
using HadiDinner.Api.UnitTests.Menus.Queries.TestUtils;
using HadiDinner.Api.UnitTests.Menus.s.TestUtils;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Application.Menus.Queries.GetMenus;
using HadiDinner.Infrastructure.Persistence.Repositories;
using UnitTests.Database;

namespace HadiDinner.Api.UnitTests.Menus.Commands.CreateMenu;

public class GetMenusTests : EFInMemoryDatabase
{
    public int T1_T2_T3;

    private readonly IMenuRepository _menuRepository;
    private readonly GetMenusQueryHandler _handler;

    public GetMenusTests()
    {
        _menuRepository = new MenuRepository(_dbContext);
        _handler = new GetMenusQueryHandler(_menuRepository);
    }

    [Fact]
    public async Task HandleGetMenusQuery_WhenMenuIsValid_ShouldCreateAndReturnMenu()
    {
        /* --------------------------------- Arrange -------------------------------- */
        var query = new GetMenusQueryUtils().CreateMenuQuery();

        var menu = new CreateMenuUtils().CreateMenu();
        Save(menu);

        /* ----------------------------------- Act ---------------------------------- */
        // Invoke the handler
        var result = await _handler.Handle(query, default);

        /* --------------------------------- Assert --------------------------------- */
        // 1. Validate correct menu created based on command
        // 2. Menu added to repository


        result.Items.Should().HaveCount(1);
        result.Items[0].Id.Should().Be(menu.Id);

        return;
    }
}
