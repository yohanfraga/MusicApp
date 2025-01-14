using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IAlbumRepository
{
    Task<bool> SaveAsync(Album album);
    Task<bool> UpdateAsync(Album album);
    Task<bool> DeleteAsync(Expression<Func<Album, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Album, bool>> predicate);
    Task<Album?> FindByPredicateAsync(
        Expression<Func<Album, bool>> predicate,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include,
        bool asNoTracking = false);
    Task<List<Album>> FindAllByPredicateAsync(
        Expression<Func<Album, bool>> predicate,
        Func<IQueryable<Album>, IIncludableQueryable<Album, object>>? include,
        bool asNoTracking = false);
}