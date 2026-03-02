using HadiDinner.Domain.Menu;

namespace HadiDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    public Task AddAsync(Menu menu);

    public Task<Menu?> GetMenuById(string menuId);

    public Task<List<Menu>> GetMenus();
}
