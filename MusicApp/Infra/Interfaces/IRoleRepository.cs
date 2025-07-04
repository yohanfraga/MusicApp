using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IRoleRepository
{
    Task<IdentityResult> SaveAsync(Role role);
    Task<bool> ActivateOrDeactivateAsync(Expression<Func<Role, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<Role, bool>> predicate);
    Task<Role?> FindByPredicateAsync(
        Expression<Func<Role, bool>> predicate,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool asNoTracking = false);
    Task<List<Role>> FindAllByPredicateAsync(
        Expression<Func<Role, bool>>? predicate = null,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool asNoTracking = false);
} 