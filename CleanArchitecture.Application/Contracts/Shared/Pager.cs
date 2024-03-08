namespace CleanArchitecture.Application.Contracts.Shared;
public class Pager
    {
    public byte pageSize = 10;
    public byte pageNumber { get; set; } = 1;
}
