namespace QC.Contracts.PaginationContracts;

public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();
    public required Meta Meta { get; init; }
}

public class Meta
{
    public int CurrentPage { get; init; } = 1;
    public int ItemsPerPage { get; init; } = 10;
    public long TotalItems { get; init; }
    public int TotalPages { get; set; }
}
