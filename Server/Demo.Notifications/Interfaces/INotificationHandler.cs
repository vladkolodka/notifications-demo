using Demo.Notifications.Models;

namespace Demo.Notifications.Interfaces
{
    public interface INotificationHandler
    {

        void Handle(NotificationInfo notificationInfo);
    }
}