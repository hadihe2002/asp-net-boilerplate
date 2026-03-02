using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.Entities;
using HadiDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HadiDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly HadiDinnerDbContext _dbContext;

    public MenuRepository(HadiDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        _dbContext.Add(menu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Menu?> GetMenuById(string menuId)
    {
        MenuId menuId1 = MenuId.Create(menuId);
        Menu? menu = await _dbContext.Menus.Where(m => m.Id == menuId1).SingleOrDefaultAsync();
        return menu;
    }

    public Task<List<Menu>> GetMenus()
    {
        return _dbContext.Menus.ToListAsync();
    }
}
