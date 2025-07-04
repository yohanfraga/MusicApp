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

public class RoleRepository(ApplicationContext dbContext, RoleManager<Role> roleManager) : BaseRepository<Role>(dbContext), IRoleRepository
{
    private const int StandardQuantity = 1;

    public async Task<IdentityResult> SaveAsync(Role role) =>
        await roleManager.CreateAsync(role);

    public async Task<bool> ActivateOrDeactivateAsync(Expression<Func<Role, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteUpdateAsync(x => x.SetProperty(r => r.Active, r => !r.Active)) >= StandardQuantity;

    public Task<bool> ExistsByPredicateAsync(Expression<Func<Role, bool>> predicate) =>
        DbSetContext.AnyAsync(predicate);

    public Task<Role?> FindByPredicateAsync(
        Expression<Func<Role, bool>> predicate,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Role> query = DbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        return query.FirstOrDefaultAsync(predicate);
    }

    public Task<List<Role>> FindAllByPredicateAsync(
        Expression<Func<Role, bool>>? predicate = null,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Role> query = DbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        if (predicate != null)
            query = query.Where(predicate);

        return query.ToListAsync();
    }
} 