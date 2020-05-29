namespace Demo.Notifications.Services
{
    using System.Threading.Tasks;
    using Hubs;
    using Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationSender : INotificationSender
    {
        public NotificationSender(IHubContext<NotificationHub> hubContext)
        {
        }

        public Task SendBroadcast(string message)
        {
            throw new System.NotImplementedException();
        }

        public Task SendDirect(string sender, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}