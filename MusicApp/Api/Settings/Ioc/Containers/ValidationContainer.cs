using MusicApp.Domain.Entities;
using MusicApp.Domain.EntitiesValidation;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class ValidationContainer

{
    public static void AddValidationContainer(this IServiceCollection services)
    {
        services.AddScoped<Validate<Album>, AlbumValidation>();
        services.AddScoped<Validate<Album>, AlbumValidation>();
        services.AddScoped<Validate<Album>, AlbumValidation>();
        services.AddScoped<Validate<Album>, AlbumValidation>();
        services.AddScoped<Validate<Album>, AlbumValidation>();
    }
}