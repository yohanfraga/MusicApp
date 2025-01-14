namespace MusicApp.Api.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionSettings(configuration);
        services.AddDatabaseSettings();
    }
}