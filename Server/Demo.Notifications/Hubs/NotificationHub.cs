using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Demo.Notifications.Hubs
{
    public class NotificationHub : Hub
	{
		// public enum ClientMethods {
		// 	ReceiveNotification,
		// };

		public override async Task OnConnectedAsync()
		{
			// TODO add user to group here
//			await Clients.Caller.SendAsync(ClientMethods.ReceiveNotification.ToString(), new NotificationDto
//            {
//				From = "Server",
//				Content = "test",
//				Type = NotificationType.Direct
//            });

            await base.OnConnectedAsync();
        }
	}
}