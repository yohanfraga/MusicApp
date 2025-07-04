using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IMusicRepository
{
    Task<bool> SaveAsync(Music music);
    Task<bool> UpdateAsync(Music music);
    Task<bool> DeleteAsync(Expression<Func<Music, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Music, bool>> predicate);
    Task<Music?> FindByPredicateAsync(
        Expression<Func<Music, bool>> predicate,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include,
        bool asNoTracking = false);
    Task<List<Music>> FindAllByPredicateAsync(
        Expression<Func<Music, bool>> predicate,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include,
        bool asNoTracking = false);
    Task<PageList<Music>> FindAllWithPaginationAsync(
        MusicPageParams pageParams,
        Expression<Func<Music, bool>>? predicate = null,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include = null);
}