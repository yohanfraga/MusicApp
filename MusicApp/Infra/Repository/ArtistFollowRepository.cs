using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class ArtistFollowRepository(ApplicationContext dbContext) 
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
}