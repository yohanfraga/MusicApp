using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface ILikeRepository
{
    Task<bool> SaveAsync(Like like);
    Task<bool> DeleteAsync(Expression<Func<Like, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Like, bool>> predicate);
    Task<Like?> FindByPredicateAsync(
        Expression<Func<Like, bool>> predicate,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include,
        bool asNoTracking = false);
    Task<List<Like>> FindAllByPredicateAsync(
        Expression<Func<Like, bool>> predicate,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include,
        bool asNoTracking = false);
}