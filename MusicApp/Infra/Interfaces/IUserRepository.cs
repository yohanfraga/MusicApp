using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<bool> SaveAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<User, bool>> predicate);
    Task<User?> FindByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include,
        bool asNoTracking = false);
    Task<List<User>> FindAllByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include,
        bool asNoTracking = false);
}