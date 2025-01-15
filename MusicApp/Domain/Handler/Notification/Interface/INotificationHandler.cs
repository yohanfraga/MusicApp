namespace MusicApp.Domain.Handler.Notification.Interface;

public interface INotificationHandler
{
    List<NotificationEntity> GetAllNotifications();
    bool HasNotification();
    void AddNotifications(IEnumerable<NotificationEntity> notifications);
    void AddNotification(NotificationEntity notification);
    bool CreateNotification(string key, string value);
}