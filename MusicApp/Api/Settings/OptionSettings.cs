using Microsoft.Extensions.Options;
using WebApplication1.Domain.Options;

namespace WebApplication1.Api.Settings;

public static class OptionSettings
{
    public static void AddOptionSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
    }
}