using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Common.Implementations.Response;
public class PagedData<T> : IPagedData<T> where T : class
{
    public List<T> dataList { get; set; }
    public int pagesCount { get; set; }
    public int rowCount { set; get; }
}
