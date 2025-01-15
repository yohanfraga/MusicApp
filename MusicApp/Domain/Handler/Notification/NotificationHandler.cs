using MusicApp.Domain.Handler.Notification.Interface;

namespace MusicApp.Domain.Handler.Notification;

public sealed class NotificationHandler : INotificationHandler
{
    private readonly List<NotificationEntity> _notifications = [];

    public List<NotificationEntity> GetAllNotifications() => _notifications;

    public bool HasNotification() => _notifications.Count != 0;

    public void AddNotifications(IEnumerable<NotificationEntity> notifications) => 
        _notifications.AddRange(notifications);

    public void AddNotification(NotificationEntity notification) => 
        _notifications.Add(notification);

    public bool CreateNotification(string key, string value)
    {
        _notifications.Add(new NotificationEntity(key, value));

        return false;
    }
}