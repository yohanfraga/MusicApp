using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IPlaylistFollowRepository
{
    Task<bool> SaveAsync(PlaylistFollow playlistFollow);
    Task<bool> DeleteAsync(Expression<Func<PlaylistFollow, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<PlaylistFollow, bool>> predicate);
    Task<PlaylistFollow?> FindByPredicateAsync(
        Expression<Func<PlaylistFollow, bool>> predicate,
        Func<IQueryable<PlaylistFollow>, IIncludableQueryable<PlaylistFollow, object>>? include,
        bool asNoTracking = false);
    Task<List<PlaylistFollow>> FindAllByPredicateAsync(
        Expression<Func<PlaylistFollow, bool>> predicate,
        Func<IQueryable<PlaylistFollow>, IIncludableQueryable<PlaylistFollow, object>>? include,
        bool asNoTracking = false);
}