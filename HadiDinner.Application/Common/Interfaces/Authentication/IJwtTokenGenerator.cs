using HadiDinner.Domain.Entities;

namespace HadiDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
