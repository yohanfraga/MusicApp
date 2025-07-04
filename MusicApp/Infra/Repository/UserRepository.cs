using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;
using Microsoft.AspNetCore.Identity;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;
using MusicApp.Infra.Interfaces.Pagination;

namespace MusicApp.Infra.Repository;

public class UserRepository(
    ApplicationContext dbContext, 
    UserManager<User> userManager,
    IPaginationQueryService<User> paginationQueryService) : BaseRepository<User>(dbContext), IUserRepository
{
    public async Task<IdentityResult> SaveAsync(User user) =>
        await userManager.CreateAsync(user);

    public async Task<IdentityResult> UpdateAsync(User user) =>
        await userManager.UpdateAsync(user);

    public async Task<IdentityResult> DeleteAsync(User user) =>
        await userManager.DeleteAsync(user);

    public Task<bool> ExistsByPredicateAsync(Expression<Func<User, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<User?> FindByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<User> query = DbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<User>> FindAllByPredicateAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<User> query = DbSetContext;
        
        if (asNoTracking)
            query = query.AsNoTracking();
        
        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }

    public async Task<PageList<User>> FindAllWithPaginationAsync(
        UserPageParams pageParams,
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
    {
        IQueryable<User> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }
    
    public string HashPassword(User user, string password) =>
        userManager.PasswordHasher.HashPassword(user, password);

    public async Task<IdentityResult> PasswordRecoveryAsync(User user, string newPassword)
    {
        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        return await userManager.ResetPasswordAsync(user, token, newPassword);
    }

    public Task<IdentityResult> ChangePasswordAsync(User entity, string currentPassword, string newPassword)
    {
        DetachedObject(entity);

        return userManager.ChangePasswordAsync(entity, currentPassword, newPassword);
    }

    private IQueryable<User> FilterPagination(IQueryable<User> query, UserPageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(u => u.Name.Contains(pageParams.Name));

        if (pageParams.Email is not null)
            query = query.Where(u => u.Email!.Contains(pageParams.Email));

        query = query.OrderBy(u => u.Id);

        return query;
    }
}