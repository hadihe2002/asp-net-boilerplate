using HadiDinner.Domain.Menu;

namespace HadiDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    public void Add(Menu menu);

    public Menu? GetMenuById(string menuId);

    public List<Menu> GetMenus();
}
