using ErrorOr;
using HadiDinner.Application.Authentication.Common;
using MediatR;

namespace HadiDinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
