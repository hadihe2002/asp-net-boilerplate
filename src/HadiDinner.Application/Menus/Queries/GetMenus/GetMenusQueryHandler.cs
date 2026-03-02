using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Menu;
using MediatR;
using QC.Contracts.PaginationContracts;

namespace HadiDinner.Application.Menus.Queries.GetMenus;

public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, PagedResult<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenusQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<PagedResult<Menu>> Handle(
        GetMenusQuery request,
        CancellationToken cancellationToken
    )
    {
        PagedResult<Menu>? menus = await _menuRepository.GetMenus(
            new PaginationDto { Page = request.Page, Limit = request.Limit }
        );
        return menus;
    }
}
