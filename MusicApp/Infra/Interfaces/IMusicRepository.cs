using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

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
}