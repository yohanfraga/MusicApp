using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;
using MusicApp.Infra.Interfaces.Pagination;

namespace MusicApp.Infra.Repository;

public class PlaylistMusicRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<PlaylistMusic> paginationQueryService)
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

    public async Task<PageList<PlaylistMusic>> FindAllWithPaginationAsync(
        PlaylistMusicPageParams pageParams,
        Expression<Func<PlaylistMusic, bool>>? predicate = null,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include = null)
    {
        IQueryable<PlaylistMusic> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<PlaylistMusic> FilterPagination(IQueryable<PlaylistMusic> query, PlaylistMusicPageParams pageParams)
    {
        if (pageParams.PlaylistId is not null)
            query = query.Where(pm => pm.PlaylistId == pageParams.PlaylistId);
            
        if (pageParams.MusicId is not null)
            query = query.Where(pm => pm.MusicId == pageParams.MusicId);

        query = query.OrderBy(pm => pm.AddedDate);

        return query;
    }
}