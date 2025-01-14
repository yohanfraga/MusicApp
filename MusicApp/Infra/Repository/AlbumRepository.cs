using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class AlbumRepository(ApplicationContext dbContext) 
    : BaseRepository<Album>(dbContext), IAlbumRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(Album album)
    {
        await DbSetContext.AddAsync(album);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Album album)
    {
        DbSetContext.Update(album);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Album, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<Album, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);
    
    public Task<Album?> FindByPredicateAsync(
        Expression<Func<Album, bool>> predicate,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Album> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Album>> FindAllByPredicateAsync(
        Expression<Func<Album, bool>>? predicate = null,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Album> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}