namespace ApplicationCore.Models
{
    using System;

    public class NotificationReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}