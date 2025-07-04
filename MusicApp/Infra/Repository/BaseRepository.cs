using Microsoft.EntityFrameworkCore;
using MusicApp.Infra.Context;

namespace MusicApp.Infra.Repository;

public abstract class BaseRepository<T>(
    ApplicationContext dbContext)
    : IDisposable where T : class
{
    private const int StandardQuantity = 0;
    
    public void Dispose()
    { 
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
    
    protected DbSet<T> DbSetContext => dbContext.Set<T>();

    protected async Task<bool> SaveInDatabaseAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken) > StandardQuantity;

    protected void DetachedObject(T entity)
    {
        if (dbContext.Entry(entity).State == EntityState.Detached)
            DbSetContext.Attach(entity);
    }
}