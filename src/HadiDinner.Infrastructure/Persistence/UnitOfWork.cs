using HadiDinner.Application.Common.Interfaces.Persistence;

namespace HadiDinner.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly HadiDinnerDbContext _dbContext;

    public UnitOfWork(HadiDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
