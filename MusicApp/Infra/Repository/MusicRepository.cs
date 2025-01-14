using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class MusicRepository(ApplicationContext dbContext) 
    : BaseRepository<Music>(dbContext), IMusicRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(Music music)
    {
        await DbSetContext.AddAsync(music);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Music music)
    {
        DbSetContext.Update(music);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Music, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<Music, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Music?> FindByPredicateAsync(
        Expression<Func<Music, bool>> predicate,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Music> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Music>> FindAllByPredicateAsync(
        Expression<Func<Music, bool>>? predicate = null,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Music> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}