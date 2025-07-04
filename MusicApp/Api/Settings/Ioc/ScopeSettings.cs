using MusicApp.Api.Settings.Ioc.Containers;
using MusicApp.Domain.Handler.Notification;
using MusicApp.Domain.Handler.Notification.Interface;
using MusicApp.Infra.Context;
using MusicApp.Infra.ORM.UnitOfWork;
using MusicApp.Infra.ORM.UnitOfWork.Interfaces;

namespace MusicApp.Api.Settings.Ioc;

public static class ScopeSettings
{
    public static void AddScopeSettings(this IServiceCollection services) =>
        services
            .AddScoped<ApplicationContext>()
            .AddScoped<INotificationHandler, NotificationHandler>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddPaginationContainer()
            .AddRepositoryContainer()
            .AddValidationContainer()
            .AddMapperContainer()
            .AddServiceContainer()
            ;
}