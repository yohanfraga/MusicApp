using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;
using MusicApp.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MusicApp.Infra.Repository;

public class UserTokenRepository(ApplicationContext dbContext) : BaseRepository<UserToken>(dbContext), IUserTokenRepository
{
    private const int StandardQuantity = 1;

    public async Task<bool> SaveAsync(UserToken token)
    {
        await DbSetContext.AddAsync(token);
        
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(UserToken token)
    {
        DbSetContext.Update(token);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<UserToken, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
} 