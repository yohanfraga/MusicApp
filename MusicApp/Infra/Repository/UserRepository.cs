using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class UserRepository(ApplicationContext dbContext) 
    : BaseRepository<User>(dbContext), IUserRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(User user)
    {
        await DbSetContext.AddAsync(user);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        DbSetContext.Update(user);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<User, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<User?> FindByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<User> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

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
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}