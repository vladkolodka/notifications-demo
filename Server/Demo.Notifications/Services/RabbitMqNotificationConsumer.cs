using Demo.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Demo.Notifications.Services
{
	using System;
	using System.Text;
	using System.Threading.Tasks;
	using Interfaces;
	using Models;
	using RabbitMQ.Client;
	using RabbitMQ.Client.Events;

	public class RabbitMqNotificationConsumer : INotificationConsumer
	{
		private readonly RabbitMqOptions _rabbitOptions;
		private IModel _channel;
		private IConnection _connection;
		private bool _disposed = false;

		public RabbitMqNotificationConsumer(IOptions<RabbitMqOptions> rabbitOptions)
		{
			_rabbitOptions = rabbitOptions.Value;
		}

		private void CreateQueueConsumer(string topicName, EventHandler<BasicDeliverEventArgs> handler)
		{
			var queueName = _channel.QueueDeclare().QueueName;
			var consumer = new EventingBasicConsumer(_channel);

			_channel.QueueBind(queue: queueName,
				exchange: _rabbitOptions.ExchangeName,
				routingKey: topicName);

			consumer.Received += handler;

			_channel.BasicConsume(queueName, true, consumer);
		}

		public async Task Run()
		{
			var factory = new ConnectionFactory {HostName = _rabbitOptions.Host, Port = _rabbitOptions.Port};

			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();

			_channel.ExchangeDeclare(_rabbitOptions.ExchangeName, ExchangeType.Topic);


			CreateQueueConsumer("notifications.broadcast", (sender, args) =>
			{
				var content = Encoding.UTF8.GetString(args.Body.ToArray());

				OnNotificationReceived?.Invoke(this,
					new NotificationReceivedEventArgs(NotificationType.Broadcast, content));
			});

			CreateQueueConsumer("notifications.direct", (sender, args) =>
			{
				var content = Encoding.UTF8.GetString(args.Body.ToArray());

				OnNotificationReceived?.Invoke(this,
					new NotificationReceivedEventArgs(NotificationType.Direct, content));
			});

			await Task.Yield();
		}

		public async Task Stop()
		{
			Dispose();

			await Task.Yield();
		}

		public event EventHandler<NotificationReceivedEventArgs> OnNotificationReceived;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				_channel?.Dispose();
				_connection?.Dispose();
			}

			_disposed = true;
		}
	}
}