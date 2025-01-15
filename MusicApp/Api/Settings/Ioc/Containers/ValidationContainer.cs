using MusicApp.Domain.Entities;
using MusicApp.Domain.EntitiesValidation;
using MusicApp.Domain.Handler.Validation.Interface;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class ValidationContainer
{
    public static IServiceCollection AddValidationContainer(this IServiceCollection services) =>
        services
            .AddScoped<IValidate<Album>, AlbumValidation>()
            .AddScoped<IValidate<Artist>, ArtistValidation>()
            .AddScoped<IValidate<Playlist>, PlaylistValidation>()
            .AddScoped<IValidate<User>, UserValidation>();
}