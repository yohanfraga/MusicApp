using MusicApp.ApplicationService.DTOs.UserDtos.Request;

namespace MusicApp.ApplicationService.Services.Interfaces;

public interface IUserCommandService : IDisposable
{
    Task<bool> RegisterAsync(UserRegisterDto registerDto);
}