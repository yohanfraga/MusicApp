using MusicApp.ApplicationService.DTOs.UserDtos.Request;
using MusicApp.Domain.Entities;

namespace MusicApp.ApplicationService.Mappers.Interfaces;

public sealed class UserMapper : IUserMapper
{
    public User RegisterDtoToEntity(UserRegisterDto registerDto) =>
        new()
        {
            Name = registerDto.Name,
            JoinDate = registerDto.JoinedDate,
            Playlists = [],
            Likes = [],
            ArtistFollows = [],
            PlaylistFollows = []
        };
}