using LEGO.AsyncAPI;
using LEGO.AsyncAPI.Models;
using MusicApp.ApplicationService.DTOs.UserDtos.Request;
using MusicApp.ApplicationService.Mappers.Interfaces;
using MusicApp.ApplicationService.Services.Interfaces;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Notification.Interface;
using MusicApp.Domain.Handler.Validation.Interface;
using MusicApp.Infra.Interfaces;

namespace MusicApp.ApplicationService.Services.UserServices;

public sealed class UserCommandService(
    IValidate<User> validate,
    INotificationHandler notification,
    IUserMapper userMapper,
    IUserRepository userRepository) : BaseService<User>(validate, notification), IUserCommandService
{
    public void Dispose() => userRepository.Dispose();
    
    public async Task<bool> RegisterAsync(UserRegisterDto registerDto)
    {
        var user = userMapper.RegisterDtoToEntity(registerDto);

        if (!await ValidateEntityAsync(user)) return false;

        return await userRepository.SaveAsync(user);
    }
}