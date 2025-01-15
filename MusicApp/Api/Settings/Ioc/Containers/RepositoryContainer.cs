using MusicApp.Infra.Interfaces;
using MusicApp.Infra.Repository;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepositoryContainer(this IServiceCollection services) =>
        services
            .AddScoped<IAlbumRepository, AlbumRepository>()
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IArtistFollowRepository, ArtistFollowRepository>()
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IMusicRepository, MusicRepository>()
            .AddScoped<IPlaylistRepository, PlaylistRepository>()
            .AddScoped<IPlaylistFollowRepository, PlaylistFollowRepository>()
            .AddScoped<IPlaylistMusicRepository, PlaylistMusicRepository>()
            .AddScoped<IUserRepository, UserRepository>();
}