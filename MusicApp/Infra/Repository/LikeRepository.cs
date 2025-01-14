using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class LikeRepository(ApplicationContext dbContext) 
    : BaseRepository<Like>(dbContext), ILikeRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(Like like)
    {
        await DbSetContext.AddAsync(like);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Like, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<Like, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Like?> FindByPredicateAsync(
        Expression<Func<Like, bool>> predicate,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Like> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Like>> FindAllByPredicateAsync(
        Expression<Func<Like, bool>>? predicate = null,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Like> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}