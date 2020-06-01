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

		public async Task SendDirect(string fromUser, string toUser, string message)
		{
			await _hubContext.Clients.Group(toUser)
				.SendAsync(NotificationHubMethods.ReceiveDirectNotification, fromUser, message);
		}
	}
}