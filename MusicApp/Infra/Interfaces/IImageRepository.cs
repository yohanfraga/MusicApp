using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Pagination;
using MusicApp.Domain.Handler.Pagination.Params;

namespace MusicApp.Infra.Interfaces;

public interface IImageRepository
{
    Task<bool> SaveAsync(Image image);
    Task<bool> UpdateAsync(Image image);
    Task<bool> DeleteAsync(Expression<Func<Image, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Image, bool>> predicate);
    Task<Image?> FindByPredicateAsync(
        Expression<Func<Image, bool>> predicate,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include,
        bool asNoTracking = false);
    Task<List<Image>> FindAllByPredicateAsync(
        Expression<Func<Image, bool>> predicate,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include,
        bool asNoTracking = false);

    Task<PageList<Image>> FindAllWithPaginationAsync(
        ImagePageParams pageParams,
        Expression<Func<Image, bool>>? predicate = null,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null);
} 