using FluentAssertions;
using HadiDinner.Api.UnitTests.Menus.Commands.TestUtils;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Application.UnitTests.Menus;
using HadiDinner.Domain.Common.Errors;
using Moq;
using UnitTests.Database;

namespace HadiDinner.Api.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests : EFInMemoryDatabase
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
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(
        CreateMenuCommand createMenuCommand
    )
    {
        /* --------------------------------- Arrange -------------------------------- */


        /* ----------------------------------- Act ---------------------------------- */
        // Invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        /* --------------------------------- Assert --------------------------------- */
        // 1. Validate correct menu created based on command
        // 2. Menu added to repository

        result.IsError.Should().BeFalse();

        var menu = result.Value;
        menu.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(r => r.AddAsync(menu), Times.Once);

        return;
    }

    [Fact]
    public async Task HandleCreateMenuCommand_WhenThereAlreadyExistsMenuWithSameName_ReturnDuplicateNameError()
    {
        var createMenuCommand = new CreateMenuCommandUtils().CreateMenuCommand();

        _mockMenuRepository.Setup(x => x.ExistsByNameAsync(It.IsAny<string>())).ReturnsAsync(true);

        var result = await _handler.Handle(createMenuCommand, default);

        result.IsError.Should().BeTrue();

        result.FirstError.Should().Be(Errors.Menu.DuplicateName);

        return;
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { new CreateMenuCommandUtils().CreateMenuCommand() };
        yield return new[]
        {
            new CreateMenuCommandUtils().WithMenuSectionCommands(3).CreateMenuCommand()
        };

        yield return new[]
        {
            new CreateMenuCommandUtils()
                .WithMenuItemCommands(4)
                .WithMenuSectionCommands(2)
                .CreateMenuCommand()
        };
    }
}
