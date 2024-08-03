using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Common.Extensions;
public static class PagedDataExtensions
{
    private const int MAX_PAGE_SIZE = 20;
    private const int MIN_PAGE_SIZE = 5;
    public static async Task<IPagedData<T>> ToPagedData<T>(this IQueryable<T> query, int pageSize, int pageNumber) where T : class
    {
        var pagedData = new PagedData<T>();

        var minpageSize = pageSize >= MIN_PAGE_SIZE ? pageSize : MIN_PAGE_SIZE;
        var realPageSize = minpageSize > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : minpageSize;
        var realpageNumber = pageNumber > 0 ? pageNumber - 1 : 1;

        pagedData.rowCount = await query.CountAsync();

        if (pagedData.rowCount > 0)
        {
            var pagesCount = (double)pagedData.rowCount / realPageSize;
            pagedData.pagesCount = (int)Math.Ceiling(pagesCount);
        }

        pagedData.dataList = await query
            .Skip(realpageNumber * realPageSize)
            .Take(realPageSize)
            .ToListAsync();

        return pagedData;
    }
}
