using MusicApp.Domain.Handler.Notification;
using MusicApp.Domain.Handler.Notification.Interface;
using MusicApp.Domain.Handler.Validation.Interface;

namespace MusicApp.ApplicationService.Services;

public abstract class BaseService<T>(IValidate<T> validate, INotificationHandler notification) where T : class
{
    protected readonly INotificationHandler Notification = notification;
    
    protected async Task<bool> ValidateEntityAsync(T entity)
    {
        var validationResponse = await validate.ValidationAsync(entity);

        if (!validationResponse.Valid)
            Notification.AddNotifications(NotificationEntity.CreateNotifications(validationResponse.Errors));

        return validationResponse.Valid;
    }
}