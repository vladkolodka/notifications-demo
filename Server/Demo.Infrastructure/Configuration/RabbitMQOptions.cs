namespace Demo.Infrastructure.Configuration
{
	public class RabbitMqOptions
	{
		public string Host { get; set; }
		public int Port { get; set; }
		public string ExchangeName { get; set; }
	}
}