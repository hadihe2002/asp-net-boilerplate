using System.Reflection;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.User;
using HadiDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace HadiDinner.Infrastructure.Persistence;

public class HadiDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public HadiDinnerDbContext(
        DbContextOptions<HadiDinnerDbContext> dbContextOptions,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor
    )
        : base(dbContextOptions)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(HadiDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
