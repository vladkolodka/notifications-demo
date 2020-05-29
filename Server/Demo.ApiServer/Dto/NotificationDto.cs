using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ApiServer.Dto
{
    public enum NotificationType {
        Direct,
        Broadcast
    }

    public class NotificationDto
    {
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public string From { get; set; }

    }
}
