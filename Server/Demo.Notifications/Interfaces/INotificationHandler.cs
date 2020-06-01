using System.Threading.Tasks;
using Demo.Notifications.Models;

namespace Demo.Notifications.Interfaces
{
    public interface INotificationHandler
    {

	    Task Handle(NotificationInfo notificationInfo);
    }
}