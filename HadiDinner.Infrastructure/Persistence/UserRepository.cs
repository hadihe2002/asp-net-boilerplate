namespace HadiDinner.Infrastructure.Persistence;

using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.User;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
