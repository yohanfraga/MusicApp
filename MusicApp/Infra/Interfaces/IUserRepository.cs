using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Infra.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<IdentityResult> SaveAsync(User user);
    Task<IdentityResult> UpdateAsync(User user);
    Task<IdentityResult> DeleteAsync(User user);
    string HashPassword(User user, string password);
    Task<IdentityResult> PasswordRecoveryAsync(User user, string newPassword);
    Task<IdentityResult> ChangePasswordAsync(User entity, string currentPassword, string newPassword);

    Task<bool> ExistsByPredicateAsync(Expression<Func<User, bool>> predicate);
    Task<User?> FindByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool asNoTracking = false);
        
    Task<List<User>> FindAllByPredicateAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool asNoTracking = false);

    Task<PageList<User>> FindAllWithPaginationAsync(
        UserPageParams pageParams,
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);
}