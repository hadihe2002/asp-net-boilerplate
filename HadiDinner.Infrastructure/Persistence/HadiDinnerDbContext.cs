using System.Reflection;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace HadiDinner.Infrastructure.Persistence;

public class HadiDinnerDbContext : DbContext
{
    public HadiDinnerDbContext(DbContextOptions<HadiDinnerDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HadiDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
