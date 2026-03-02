using HadiDinner.Domain.Common.Models;
using HadiDinner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Database;

public class EFInMemoryDatabase
{
    protected readonly HadiDinnerDbContext _dbContext;

    public EFInMemoryDatabase()
    {
        var dbName = Guid.NewGuid().ToString();

        var options = new DbContextOptionsBuilder<HadiDinnerDbContext>()
            .UseInMemoryDatabase(dbName)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options;

        _dbContext = new HadiDinnerDbContext(options);
    }

    protected void Save(params IAggregateRoot[] aggregateRoots)
    {
        if (aggregateRoots is null || aggregateRoots.Length == 0)
        {
            return;
        }

        _dbContext.AddRange(aggregateRoots);
        _dbContext.SaveChanges();
    }
}
