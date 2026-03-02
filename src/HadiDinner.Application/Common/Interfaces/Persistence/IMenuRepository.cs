using HadiDinner.Domain.Menu;
using QC.Contracts.PaginationContracts;

namespace HadiDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    public Task AddAsync(Menu menu);
    public Task<Menu?> GetMenuById(string menuId);
    public Task<PagedResult<Menu>> GetMenus(PaginationDto paginationDto);
    public Task<bool> ExistsByNameAsync(string Name);
}
