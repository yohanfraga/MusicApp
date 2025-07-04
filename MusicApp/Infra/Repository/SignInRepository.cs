using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Interfaces;

namespace MusicApp.Infra.Repository;

public class SignInRepository(SignInManager<User> signInManager) : ISignInRepository
{
    public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure) =>
        await signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

    public async Task SignOutAsync() => await signInManager.SignOutAsync();
} 