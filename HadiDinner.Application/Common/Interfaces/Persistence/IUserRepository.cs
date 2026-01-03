namespace HadiDinner.Application.Common.Interfaces.Persistence;

using HadiDinner.Domain.Entities;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}
