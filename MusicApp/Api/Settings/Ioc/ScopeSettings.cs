using MusicApp.Api.Settings.Ioc.Containers;
using MusicApp.Infra.Context;

namespace MusicApp.Api.Settings.Ioc;

public static class ScopeSettings
{
    public static void AddScopeSettings(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();
        services.AddRepositoryContainer();
    }
}