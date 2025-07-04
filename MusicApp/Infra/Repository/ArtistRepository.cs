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

public class ArtistRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<Artist> paginationQueryService) 
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

    public async Task<PageList<Artist>> FindAllWithPaginationAsync(
        ArtistPageParams pageParams,
        Expression<Func<Artist, bool>>? predicate = null,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null)
    {
        IQueryable<Artist> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<Artist> FilterPagination(IQueryable<Artist> query, ArtistPageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(a => a.Name.Contains(pageParams.Name));

        query = query.OrderBy(a => a.Id);

        return query;
    }
}