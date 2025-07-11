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

public class PlaylistRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<Playlist> paginationQueryService) 
    : BaseRepository<Playlist>(dbContext), IPlaylistRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(Playlist playlist)
    {
        await DbSetContext.AddAsync(playlist);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Playlist playlist)
    {
        DbSetContext.Update(playlist);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Playlist, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<Playlist, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Playlist?> FindByPredicateAsync(
        Expression<Func<Playlist, bool>> predicate,
        Func<IQueryable<Playlist>, IIncludableQueryable<Playlist, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Playlist> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Playlist>> FindAllByPredicateAsync(
        Expression<Func<Playlist, bool>>? predicate = null,
        Func<IQueryable<Playlist>, IIncludableQueryable<Playlist, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Playlist> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }

    public async Task<PageList<Playlist>> FindAllWithPaginationAsync(
        PlaylistPageParams pageParams,
        Expression<Func<Playlist, bool>>? predicate = null,
        Func<IQueryable<Playlist>, IIncludableQueryable<Playlist, object>>? include = null)
    {
        IQueryable<Playlist> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<Playlist> FilterPagination(IQueryable<Playlist> query, PlaylistPageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(p => p.Name.Contains(pageParams.Name));
            
        if (pageParams.UserId is not null)
            query = query.Where(p => p.UserId == pageParams.UserId);

        query = query.OrderBy(p => p.Id);

        return query;
    }
}