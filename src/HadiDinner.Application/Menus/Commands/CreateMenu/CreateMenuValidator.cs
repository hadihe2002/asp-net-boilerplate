using FluentValidation;

namespace HadiDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
        RuleFor(x => x.HostId).Must(BeValidGuid).WithMessage("Host Id should be Guid");
    }

    private bool BeValidGuid(string value)
    {
        return Guid.TryParse(value, out _);
    }
}
