using ErrorOr;
using HadiDinner.Application.Authentication.Common;
using MediatR;

namespace HadiDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;
