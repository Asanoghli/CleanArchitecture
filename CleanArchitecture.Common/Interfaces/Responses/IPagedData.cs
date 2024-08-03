using System.Runtime.CompilerServices;

namespace CleanArchitecture.Common.Interfaces.Responses;
public interface IPagedData<T> where T : class
{
    List<T> dataList { get; set; }
    int pagesCount { get; set; }
    int rowCount { get; set; }
}
