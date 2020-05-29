namespace Demo.Notifications.Services
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    // TODO
    public class RabbitMqNotificationConsumer : INotificationConsumer
    {
        private IModel _channel;
        private IConnection _connection;

        public async Task Run()
        {
            // TODO config
            var factory = new ConnectionFactory {HostName = "localhost", Port = 32769};

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("logs", ExchangeType.Fanout);

            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queueName, "logs", "");

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                OnNotificationReceived?.Invoke(this, new NotificationReceivedEventArgs
                {
                    Message = message
                });
            };

            _channel.BasicConsume(queueName, true, consumer);
            await Task.Yield();
        }

        public async Task Stop()
        {
            _channel.Abort();
            _connection.Abort();

            await Task.Yield();
        }

        public event EventHandler<NotificationReceivedEventArgs> OnNotificationReceived;

        public void Dispose()
        {
            // TODO fix
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}