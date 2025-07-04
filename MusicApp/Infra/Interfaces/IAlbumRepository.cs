using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IAlbumRepository
{
    Task<bool> SaveAsync(Album album);
    Task<bool> UpdateAsync(Album album);
    Task<bool> DeleteAsync(Expression<Func<Album, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Album, bool>> predicate);
    Task<Album?> FindByPredicateAsync(
        Expression<Func<Album, bool>> predicate,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include,
        bool asNoTracking = false);
    Task<List<Album>> FindAllByPredicateAsync(
        Expression<Func<Album, bool>> predicate,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include,
        bool asNoTracking = false);
    Task<PageList<Album>> FindAllWithPaginationAsync(
        AlbumPageParams pageParams,
        Expression<Func<Album, bool>>? predicate = null,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include = null);
}