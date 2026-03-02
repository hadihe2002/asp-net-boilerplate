using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.User;

namespace HadiDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HadiDinnerDbContext _dbContext;

    public UserRepository(HadiDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
    }
}
