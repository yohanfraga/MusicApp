using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Options;
using WebApplication1.Infra.Context;

namespace WebApplication1.Api.Settings;

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