using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.Interfaces;

public interface ISignInRepository
{
    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    Task SignOutAsync();
} 