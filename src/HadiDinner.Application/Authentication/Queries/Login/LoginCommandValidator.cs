using FluentValidation;

namespace HadiDinner.Application.Authentication.Queries.Login;

public class LoginCommandValidator : AbstractValidator<LoginQuery>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
