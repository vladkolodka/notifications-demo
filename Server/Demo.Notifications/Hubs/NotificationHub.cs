using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Demo.Notifications.Hubs
{
    public class NotificationHub : Hub
	{
		public enum ClientMethods {
			ReceiveNotification
		};

		public override async Task OnConnectedAsync()
		{
//			await Clients.Caller.SendAsync(ClientMethods.ReceiveNotification.ToString(), new NotificationDto
//            {
//				From = "Server",
//				Message = "test",
//				Type = NotificationType.Direct
//            });

            await base.OnConnectedAsync();
        }
	}
}