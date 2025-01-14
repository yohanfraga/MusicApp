using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IPlaylistRepository
{
    Task<bool> SaveAsync(Playlist playlist);
    Task<bool> UpdateAsync(Playlist playlist);
    Task<bool> DeleteAsync(Expression<Func<Playlist, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Playlist, bool>> predicate);
    Task<Playlist?> FindByPredicateAsync(
        Expression<Func<Playlist, bool>> predicate,
        Func<IQueryable<Playlist>, IIncludableQueryable<Playlist, object>>? include,
        bool asNoTracking = false);
    Task<List<Playlist>> FindAllByPredicateAsync(
        Expression<Func<Playlist, bool>> predicate,
        Func<IQueryable<Playlist>, IIncludableQueryable<Playlist, object>>? include,
        bool asNoTracking = false);
}