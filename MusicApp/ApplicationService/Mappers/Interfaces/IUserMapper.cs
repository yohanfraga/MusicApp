using MusicApp.ApplicationService.DTOs.UserDtos.Request;
using MusicApp.Domain.Entities;

namespace MusicApp.ApplicationService.Mappers.Interfaces;

public interface IUserMapper
{
    User RegisterDtoToEntity(UserRegisterDto registerDto);
}