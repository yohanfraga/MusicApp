using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Options;
using MusicApp.Infra.Context;

namespace MusicApp.Api.Settings;

public static class DatabaseSettings
{
    public static void AddDatabaseSettings(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
            options.UseSqlServer(
                serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection, 
                sql => sql.CommandTimeout(180)));
    }
}