using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IArtistFollowRepository
{
    Task<bool> SaveAsync(ArtistFollow artistFollow);
    Task<bool> DeleteAsync(Expression<Func<ArtistFollow, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<ArtistFollow, bool>> predicate);

    Task<ArtistFollow?> FindByPredicateAsync(
        Expression<Func<ArtistFollow, bool>> predicate,
        Func<IQueryable<ArtistFollow>, IIncludableQueryable<ArtistFollow, object>>? include,
        bool asNoTracking = false);
    Task<List<ArtistFollow>> FindAllByPredicateAsync(
        Expression<Func<ArtistFollow, bool>> predicate,
        Func<IQueryable<ArtistFollow>, IIncludableQueryable<ArtistFollow, object>>? include,
        bool asNoTracking = false);
}