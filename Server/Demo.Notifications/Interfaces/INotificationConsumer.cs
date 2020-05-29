namespace Demo.Notifications.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public interface INotificationConsumer : IDisposable
    {
        Task Run();
        Task Stop();

        event EventHandler<NotificationReceivedEventArgs> OnNotificationReceived;
    }
}