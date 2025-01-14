using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class PlaylistFollowRepository(ApplicationContext dbContext) 
    : BaseRepository<PlaylistFollow>(dbContext), IPlaylistFollowRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(PlaylistFollow playlistFollow)
    {
        await DbSetContext.AddAsync(playlistFollow);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<PlaylistFollow, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<PlaylistFollow, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<PlaylistFollow?> FindByPredicateAsync(
        Expression<Func<PlaylistFollow, bool>> predicate,
        Func<IQueryable<PlaylistFollow>, IIncludableQueryable<PlaylistFollow, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<PlaylistFollow> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<PlaylistFollow>> FindAllByPredicateAsync(
        Expression<Func<PlaylistFollow, bool>>? predicate = null,
        Func<IQueryable<PlaylistFollow>, IIncludableQueryable<PlaylistFollow, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<PlaylistFollow> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
}