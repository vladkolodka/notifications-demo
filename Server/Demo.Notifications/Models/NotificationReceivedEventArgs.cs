namespace Demo.Notifications.Models
{
    using System;

    public class NotificationReceivedEventArgs : EventArgs
    {
	    public NotificationReceivedEventArgs(NotificationType type, string content)
	    {
		    Content = new NotificationInfo
		    {
				Type = type,
				Content = content
			};
	    }

	    public NotificationInfo Content { get; set; }
    }
}