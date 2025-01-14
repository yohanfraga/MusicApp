using MusicApp.Infra.Interfaces;
using MusicApp.Infra.Repository;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class RepositoryContainer
{
    public static void AddRepositoryContainer(this IServiceCollection services)
    {
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IArtistFollowRepository, ArtistFollowRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IMusicRepository, MusicRepository>();
        services.AddScoped<IPlaylistRepository, PlaylistRepository>();
        services.AddScoped<IPlaylistFollowRepository, PlaylistFollowRepository>();
        services.AddScoped<IPlaylistMusicRepository, PlaylistMusicRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}