using HadiDinner.Domain.Menu;
using MediatR;
using QC.Contracts.PaginationContracts;

namespace HadiDinner.Application.Menus.Queries.GetMenus;

public record GetMenusQuery(int Limit, int Page) : IRequest<PagedResult<Menu>>;
