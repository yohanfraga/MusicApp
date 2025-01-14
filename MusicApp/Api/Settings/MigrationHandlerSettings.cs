using Microsoft.EntityFrameworkCore;
using MusicApp.Infra.Context;

namespace MusicApp.Api.Settings;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        
        await appContext.Database.MigrateAsync();
    }
}