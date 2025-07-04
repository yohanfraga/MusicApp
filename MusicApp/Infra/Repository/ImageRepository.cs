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

public class ImageRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<Image> paginationQueryService)
    : BaseRepository<Image>(dbContext), IImageRepository
{
    private const int StandardQuantity = 1;

    public Task<List<Image>> FindAllByPredicateAsync(
        Expression<Func<Image, bool>>? predicate = null,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Image> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }

    public async Task<PageList<Image>> FindAllWithPaginationAsync(
        ImagePageParams pageParams,
        Expression<Func<Image, bool>>? predicate = null,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null)
    {
        IQueryable<Image> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<Image> FilterPagination(IQueryable<Image> query, ImagePageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(i => i.Name.Contains(pageParams.Name));

        query = query.OrderBy(i => i.Id);

        return query;
    }

    public async Task<bool> SaveAsync(Image image)
    {
        await DbSetContext.AddAsync(image);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Image image)
    {
        DbSetContext.Update(image);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Image, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<Image, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Image?> FindByPredicateAsync(
        Expression<Func<Image, bool>> predicate,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Image> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }
} 