using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class UserRoleRepository(ApplicationContext dbContext) : BaseRepository<UserRole>(dbContext), IUserRoleRepository
{
    private const int StandardQuantity = 1;

    public async Task<bool> SaveAsync(UserRole userRole)
    {
        await DbSetContext.AddAsync(userRole);
        
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<UserRole, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<UserRole, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<UserRole?> FindByPredicateAsync(
        Expression<Func<UserRole, bool>> predicate,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<UserRole> query = DbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<UserRole>> FindAllByPredicateAsync(
        Expression<Func<UserRole, bool>>? predicate = null,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<UserRole> query = DbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        if (predicate != null)
            query = query.Where(predicate);

        return query.ToListAsync();
    }
} 