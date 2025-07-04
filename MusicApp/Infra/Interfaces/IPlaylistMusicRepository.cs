using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IPlaylistMusicRepository
{
    Task<bool> SaveAsync(PlaylistMusic playlistMusic);
    Task<bool> DeleteAsync(Expression<Func<PlaylistMusic, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<PlaylistMusic, bool>> predicate);
    Task<PlaylistMusic?> FindByPredicateAsync(
        Expression<Func<PlaylistMusic, bool>> predicate,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include,
        bool asNoTracking = false);
    Task<List<PlaylistMusic>> FindAllByPredicateAsync(
        Expression<Func<PlaylistMusic, bool>> predicate,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include,
        bool asNoTracking = false);
    
    Task<PageList<PlaylistMusic>> FindAllWithPaginationAsync(
        PlaylistMusicPageParams pageParams,
        Expression<Func<PlaylistMusic, bool>>? predicate = null,
        Func<IQueryable<PlaylistMusic>, IIncludableQueryable<PlaylistMusic, object>>? include = null);
}