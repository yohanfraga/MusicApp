using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Infra.Context;

public sealed class ApplicationContext(
    DbContextOptions<ApplicationContext> dbContext) 
    : DbContext(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}