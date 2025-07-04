using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IAudioRepository
{
    Task<bool> SaveAsync(Audio audio);
    Task<bool> UpdateAsync(Audio audio);
    Task<bool> DeleteAsync(Expression<Func<Audio, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Audio, bool>> predicate);
    Task<Audio?> FindByPredicateAsync(
        Expression<Func<Audio, bool>> predicate,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include,
        bool asNoTracking = false);
    Task<List<Audio>> FindAllByPredicateAsync(
        Expression<Func<Audio, bool>>? predicate,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include,
        bool asNoTracking = false);
    Task<PageList<Audio>> FindAllWithPaginationAsync(
        AudioPageParams pageParams,
        Expression<Func<Audio, bool>>? predicate = null,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include = null);
} 