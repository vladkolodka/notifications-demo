namespace Demo.Notifications.Workers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using Models;

    public class NotificationConsumerWorker : IHostedService, IDisposable
    {
        private readonly INotificationConsumer _notificationConsumer;
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificationConsumerWorker(INotificationConsumer notificationConsumer, IServiceScopeFactory scopeFactory)
        {
            _notificationConsumer = notificationConsumer;
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _notificationConsumer.OnNotificationReceived += OnNotificationReceivedHandler;
            await _notificationConsumer.Run();
        }

        private void OnNotificationReceivedHandler(object sender, NotificationReceivedEventArgs e)
        {
            // TODO think about parallel handling : async
            using var scope = _scopeFactory.CreateScope();

            var notificationHandler = scope.ServiceProvider.GetService<INotificationHandler>();

            notificationHandler.Handle(e.Message);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _notificationConsumer.Stop();
        }

        public void Dispose()
        {
            _notificationConsumer.Dispose();
        }
    }
}