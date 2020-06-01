namespace Demo.Notifications.Interfaces
{
    using System.Threading.Tasks;

    public interface INotificationSender
    {
        Task SendBroadcast(string message);
        Task SendDirect(string fromUser, string toUser, string message);
    }
}