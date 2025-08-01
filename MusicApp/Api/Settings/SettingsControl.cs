﻿using MusicApp.Api.Settings.Handlers;

namespace MusicApp.Api.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentitySettings();
        services.AddOptionSettings(configuration);
        services.AddControllersSettings();
        services.AddFiltersSettings();
        services.AddDatabaseSettings();
    }
}