using FluentValidation;

namespace HadiDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Password).MinimumLength(8).MaximumLength(100).NotEmpty();
    }
}
