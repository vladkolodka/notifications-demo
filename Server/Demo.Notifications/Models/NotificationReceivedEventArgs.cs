namespace Demo.Notifications.Models
{
    using System;

    public class NotificationReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}