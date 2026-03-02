using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Menu;
using HadiDinner.Domain.Menu.ValueObjects;
using HadiDinner.Infrastructure.Persistence.Pagination;
using Microsoft.EntityFrameworkCore;
using QC.Contracts.PaginationContracts;

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
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _dbContext.Menus.AnyAsync(m => m.Name == name);
    }

    public async Task<Menu?> GetMenuById(string menuId)
    {
        MenuId menuId1 = MenuId.Create(menuId);
        Menu? menu = await _dbContext.Menus.Where(m => m.Id == menuId1).SingleOrDefaultAsync();
        return menu;
    }

    public async Task<PagedResult<Menu>> GetMenus(PaginationDto paginationDto)
    {
        return await _dbContext.Menus.ToPagedResultAsync(paginationDto);
    }
}
