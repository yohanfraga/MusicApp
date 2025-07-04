using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Infra.Interfaces.Pagination;

public interface IPaginationQueryService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
}