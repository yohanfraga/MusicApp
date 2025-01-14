using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class ArtistRepository(ApplicationContext dbContext) 
    : BaseRepository<Artist>(dbContext), IArtistRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(Artist artist)
    {
        await DbSetContext.AddAsync(artist);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Artist artist)
    {
        DbSetContext.Update(artist);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Artist, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<Artist, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Artist?> FindByPredicateAsync(
        Expression<Func<Artist, bool>> predicate,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Artist> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Artist>> FindAllByPredicateAsync(
        Expression<Func<Artist, bool>>? predicate = null,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Artist> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}