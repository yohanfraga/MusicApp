using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface IUserRoleRepository
{
    Task<bool> SaveAsync(UserRole userRole);
    Task<bool> DeleteAsync(Expression<Func<UserRole, bool>> predicate);
    Task<bool> ExistsByPredicateAsync(Expression<Func<UserRole, bool>> predicate);
    Task<UserRole?> FindByPredicateAsync(
        Expression<Func<UserRole, bool>> predicate,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool asNoTracking = false);
    Task<List<UserRole>> FindAllByPredicateAsync(
        Expression<Func<UserRole, bool>>? predicate = null,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool asNoTracking = false);
} 