using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using QC.Contracts.PaginationContracts;

namespace HadiDinner.Infrastructure.Persistence.Pagination;

public static class PaginationExtensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        PaginationDto paginationDto
    )
    {
        var totalItems = await query.LongCountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)paginationDto.Limit);

        var items = await query
            .Skip((paginationDto.Page - 1) * paginationDto.Limit)
            .Take(paginationDto.Limit)
            .ToListAsync();

        return new PagedResult<T>
        {
            Items = items,
            Meta = new()
            {
                CurrentPage = paginationDto.Page,
                ItemsPerPage = paginationDto.Limit,
                TotalItems = totalItems,
                TotalPages = totalPages
            }
        };
    }
}
