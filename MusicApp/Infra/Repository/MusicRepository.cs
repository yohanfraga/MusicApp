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

public class MusicRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<Music> paginationQueryService) 
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

    public async Task<PageList<Music>> FindAllWithPaginationAsync(
        MusicPageParams pageParams,
        Expression<Func<Music, bool>>? predicate = null,
        Func<IQueryable<Music>, IIncludableQueryable<Music, object>>? include = null)
    {
        IQueryable<Music> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<Music> FilterPagination(IQueryable<Music> query, MusicPageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(m => m.Name.Contains(pageParams.Name));
        
        if (pageParams.AlbumId is not null)
            query = query.Where(m => m.AlbumId == pageParams.AlbumId);

        query = query.OrderBy(m => m.Id);

        return query;
    }
}