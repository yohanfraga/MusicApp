namespace MusicApp.Domain.Handler.Notification;

public sealed class NotificationEntity(string key, string value)
{
    public string Key { get; init; } = key;
    public string Value { get; init; } = value;

    public static IEnumerable<NotificationEntity> CreateNotifications(Dictionary<string, string> validationErrors) =>
        validationErrors
            .Select(notification => 
                new NotificationEntity(notification.Key, notification.Value)
            );
}