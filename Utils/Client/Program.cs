using System;
using System.Text;
using RabbitMQ.Client;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("RabbitMQ Client.\nSelect notification type:\n1 - direct\n2 - broadcast");
			
			var routingKey = Console.Read() switch
			{
				'1' => "notifications.direct",
				'2' => "notifications.broadcast",
				_ => throw new ArgumentException("Unknown command.")
			};

			var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: "notifications", type: ExchangeType.Topic);

				var message = "test message";
				var body = Encoding.UTF8.GetBytes(message);
				channel.BasicPublish(exchange: "notifications", routingKey: routingKey, basicProperties: null, body: body);
				Console.WriteLine(" [x] Sent {0}", message);
			}

			Console.WriteLine(" Press [enter] to exit.");
		}
	}
}
