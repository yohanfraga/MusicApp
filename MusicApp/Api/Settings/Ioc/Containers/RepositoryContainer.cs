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
            .AddScoped<IAudioRepository, AudioRepository>()
            .AddScoped<IImageRepository, ImageRepository>()
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IMusicRepository, MusicRepository>()
            .AddScoped<IPlaylistRepository, PlaylistRepository>()
            .AddScoped<IPlaylistFollowRepository, PlaylistFollowRepository>()
            .AddScoped<IPlaylistMusicRepository, PlaylistMusicRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserRoleRepository, UserRoleRepository>()
            .AddScoped<IUserTokenRepository, UserTokenRepository>()
            .AddScoped<ISignInRepository, SignInRepository>()
            ;
}