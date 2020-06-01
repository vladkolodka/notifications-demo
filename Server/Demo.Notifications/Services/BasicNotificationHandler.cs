using System;
using System.Text.Json;
using Demo.Notifications.Models;

namespace Demo.Notifications.Services
{
	using Infrastructure.Data;
	using Infrastructure.Services;
	using Interfaces;
	using Microsoft.Extensions.Logging;

	public class BasicNotificationHandler : BaseService, INotificationHandler
	{
		private readonly INotificationSender _notificationSender;
		private readonly ILogger<INotificationHandler> _logger;

		public BasicNotificationHandler(AppDataContext dataContext, INotificationSender notificationSender,
			ILogger<INotificationHandler> logger) : base(dataContext)
		{
			_notificationSender = notificationSender;
			_logger = logger;
		}


		public void Handle(NotificationInfo notificationInfo)
		{
			var notification = JsonSerializer.Deserialize<NotificationContent>(notificationInfo.Content);

			await notificationInfo.Type switch
			{
				NotificationType.Broadcast => _notificationSender.SendBroadcast(notification.Message),
				NotificationType.Direct => _notificationSender.SendDirect(notification.From, notification.Message),
				_ => throw new ArgumentException(),
			};


//            throw new System.NotImplementedException();
		}
	}
}