namespace QC.Contracts.PaginationContracts;

public class PaginationDto
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}
