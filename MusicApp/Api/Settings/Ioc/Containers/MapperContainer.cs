using MusicApp.ApplicationService.Mappers.Interfaces;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class MapperContainer
{
    public static IServiceCollection AddMapperContainer(this IServiceCollection services) =>
        services
            .AddScoped<IUserMapper, UserMapper>();
}