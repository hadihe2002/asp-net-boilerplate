using HadiDinner.Domain.Entities;

namespace HadiDinner.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);
