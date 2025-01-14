using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class PlaylistMusicRepository(ApplicationContext dbContext) 
    : BaseRepository<PlaylistMusic>(dbContext), IPlaylistMusicRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(PlaylistMusic playlistMusic)
    {
        await DbSetContext.AddAsync(playlistMusic);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<PlaylistMusic, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<PlaylistMusic, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<PlaylistMusic?> FindByPredicateAsync(
        Expression<Func<PlaylistMusic, bool>> predicate,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<PlaylistMusic> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<PlaylistMusic>> FindAllByPredicateAsync(
        Expression<Func<PlaylistMusic, bool>>? predicate = null,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<PlaylistMusic> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}