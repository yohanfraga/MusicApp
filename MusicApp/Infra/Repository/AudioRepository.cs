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

public class AudioRepository(
    ApplicationContext dbContext,
    IPaginationQueryService<Audio> paginationQueryService)
    : BaseRepository<Audio>(dbContext), IAudioRepository
{
    private const int StandardQuantity = 1;

    public Task<List<Audio>> FindAllByPredicateAsync(
        Expression<Func<Audio, bool>>? predicate = null,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Audio> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);
        
        return query.ToListAsync();
    }

    public async Task<PageList<Audio>> FindAllWithPaginationAsync(
        AudioPageParams pageParams,
        Expression<Func<Audio, bool>>? predicate = null,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include = null)
    {
        IQueryable<Audio> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        query = FilterPagination(query, pageParams);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    private IQueryable<Audio> FilterPagination(IQueryable<Audio> query, AudioPageParams pageParams)
    {
        if (pageParams.Name is not null)
            query = query.Where(a => a.Name.Contains(pageParams.Name));

        query = query.OrderBy(a => a.Id);

        return query;
    }

    public async Task<bool> SaveAsync(Audio audio)
    {
        await DbSetContext.AddAsync(audio);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Audio audio)
    {
        DbSetContext.Update(audio);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Audio, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<Audio, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);
    
    public Task<Audio?> FindByPredicateAsync(
        Expression<Func<Audio, bool>> predicate,
        Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>? include,
        bool asNoTracking = false)
    {
        IQueryable<Audio> query = DbSetContext;

        if (asNoTracking)
            query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }
} 