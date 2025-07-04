using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IArtistRepository
{
    Task<bool> SaveAsync(Artist artist);
    Task<bool> UpdateAsync(Artist artist);
    Task<bool> DeleteAsync(Expression<Func<Artist, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Artist, bool>> predicate);
    Task<Artist?> FindByPredicateAsync(
        Expression<Func<Artist, bool>> predicate,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include,
        bool asNoTracking = false);
    Task<List<Artist>> FindAllByPredicateAsync(
        Expression<Func<Artist, bool>> predicate,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include,
        bool asNoTracking = false);
    Task<PageList<Artist>> FindAllWithPaginationAsync(
        ArtistPageParams pageParams,
        Expression<Func<Artist, bool>>? predicate = null,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null);
}