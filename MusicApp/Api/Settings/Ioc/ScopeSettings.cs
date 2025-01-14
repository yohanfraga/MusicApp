using WebApplication1.Infra.Context;

namespace WebApplication1.Api.Settings.Ioc;

public static class ScopeSettings
{
    public static void AddScopeSettings(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();
        
    }
}