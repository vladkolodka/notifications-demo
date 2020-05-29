namespace Demo.Notifications.Interfaces
{
    using System.Threading.Tasks;

    public interface INotificationSender
    {
        Task SendBroadcast(string message);
        Task SendDirect(string from, string message);
    }
}