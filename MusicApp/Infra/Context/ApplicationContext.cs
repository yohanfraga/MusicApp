using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MusicApp.Infra.Context;

public sealed class ApplicationContext(
    DbContextOptions<ApplicationContext> dbContext) 
    : IdentityDbContext<
        User,
        Role,
        Guid,
        UserClaim,
        UserRole,
        UserLogin,
        RoleClaim,
        UserToken>(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}