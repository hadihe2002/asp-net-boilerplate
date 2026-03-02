using FluentAssertions;
using HadiDinner.Api.UnitTests.Menus.Commands.TestUtils;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Application.UnitTests.Menus;
using Moq;

namespace HadiDinner.Api.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    public int T1_T2_T3;

    private readonly Mock<IMenuRepository> _mockMenuRepository;
    private readonly CreateMenuCommandHandler _handler;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu()
    {
        /* --------------------------------- Arrange -------------------------------- */
        //  Get Hold of a valid Menu
        var createMenuCommand = new CreateMenuCommandUtils().Create();

        /* ----------------------------------- Act ---------------------------------- */
        // Invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        /* --------------------------------- Assert --------------------------------- */
        // 1. Validate correct menu created based on command
        // 2. Menu added to repository

        result.IsError.Should().BeFalse();

        var menu = result.Value;
        menu.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(menu), Times.Once);

        return;
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        throw new NotImplementedException();
    }
}
