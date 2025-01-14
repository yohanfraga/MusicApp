using MusicApp.Api.Filters;

namespace MusicApp.Api.Settings.Handlers;

public static class FiltersSettings
{
    public static void AddFiltersSettings(this IServiceCollection services)
    {
        services.AddMvc(config => config.Filters.AddService<UnitOfWorkFilter>());

        services.AddScoped<UnitOfWorkFilter>();
    }
}