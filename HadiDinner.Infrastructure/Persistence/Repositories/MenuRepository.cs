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

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }

    public Menu? GetMenuById(string menuId)
    {
        MenuId menuId1 = MenuId.Create(menuId);
        Menu? menu = _dbContext.Menus.Where(m => m.Id == menuId1).SingleOrDefault();
        return menu;
    }

    public List<Menu> GetMenus()
    {
        return _dbContext.Menus.ToList();
    }
}
