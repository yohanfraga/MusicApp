using MusicApp.Domain.Entities;
using System.Linq.Expressions;

namespace MusicApp.Infra.Interfaces;

public interface IUserTokenRepository
{
    Task<bool> SaveAsync(UserToken token);
    Task<bool> UpdateAsync(UserToken token);
    Task<bool> DeleteAsync(Expression<Func<UserToken, bool>> predicate);
} 