using RabbitMQ.Client;

namespace Subscriber1.src.Infrastructure.RabbitMQ
{

    public class RabbitMqConfig
    {
        public static IConnection CreateConnection(string hostName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            return factory.CreateConnection();
        }

        public static IModel CreateChannel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}
