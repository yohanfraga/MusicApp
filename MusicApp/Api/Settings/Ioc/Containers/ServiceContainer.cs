using MusicApp.ApplicationService.Services.Interfaces;
using MusicApp.ApplicationService.Services.UserServices;

namespace MusicApp.Api.Settings.Ioc.Containers;

public static class ServiceContainer
{
    public static IServiceCollection AddServiceContainer(this IServiceCollection services) =>
        services
            .AddScoped<IUserCommandService, UserCommandService>();
}