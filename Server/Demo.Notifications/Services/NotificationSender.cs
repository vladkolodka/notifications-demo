namespace Demo.Notifications.Services
{
    using System.Threading.Tasks;
    using Hubs;
    using Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationSender : INotificationSender
    {
	    private readonly IHubContext<NotificationHub> _hubContext;

	    public NotificationSender(IHubContext<NotificationHub> hubContext)
	    {
		    _hubContext = hubContext;
	    }

        public async Task SendBroadcast(string message)
        {
	        await _hubContext.Clients.All.SendAsync(NotificationHubMethods.ReceiveBroadcastNotification, message);
        }

        public Task SendDirect(string sender, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}