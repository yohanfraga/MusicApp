using MusicApp.Domain.Handler.Pagination;
using MusicApp.Infra.Interfaces.Pagination;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Infra.Pagination;

public class PaginationQueryService<T> : IPaginationQueryService<T> where T : class
{
    public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }
}