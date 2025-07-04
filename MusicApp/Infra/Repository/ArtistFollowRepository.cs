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

public class ArtistFollowRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<ArtistFollow> paginationQueryService) 
    : BaseRepository<ArtistFollow>(dbContext), IArtistFollowRepository
{
    private const int StandardQuantity = 1;
    
    public async Task<bool> SaveAsync(ArtistFollow artistFollow)
    {
        await DbSetContext.AddAsync(artistFollow);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<ArtistFollow, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
    
    public Task<bool> ExistsByPredicateAsync(Expression<Func<ArtistFollow, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<ArtistFollow?> FindByPredicateAsync(
        Expression<Func<ArtistFollow, bool>> predicate,
        Func<IQueryable<ArtistFollow>, IIncludableQueryable<ArtistFollow, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<ArtistFollow> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<ArtistFollow>> FindAllByPredicateAsync(
        Expression<Func<ArtistFollow, bool>>? predicate = null,
        Func<IQueryable<ArtistFollow>, IIncludableQueryable<ArtistFollow, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<ArtistFollow> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }
    
    public async Task<PageList<ArtistFollow>> FindAllWithPaginationAsync(
        ArtistFollowPageParams pageParams,
        Expression<Func<ArtistFollow, bool>>? predicate = null,
        Func<IQueryable<ArtistFollow>, IIncludableQueryable<ArtistFollow, object>>? include = null)
    {
        IQueryable<ArtistFollow> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<ArtistFollow> FilterPagination(IQueryable<ArtistFollow> query, ArtistFollowPageParams pageParams)
    {
        if (pageParams.UserId is not null)
            query = query.Where(af => af.UserId == pageParams.UserId);
            
        if (pageParams.ArtistId is not null)
            query = query.Where(af => af.ArtistId == pageParams.ArtistId);

        query = query.OrderBy(af => af.FollowDate);

        return query;
    }
}