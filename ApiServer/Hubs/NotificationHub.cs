using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ApiServer.Hubs
{
	public class NotificationHub : Hub
	{
		public override Task OnConnectedAsync()
		{
			return base.OnConnectedAsync();
		}
	}
}