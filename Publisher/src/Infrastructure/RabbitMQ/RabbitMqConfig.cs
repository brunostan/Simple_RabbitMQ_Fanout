using RabbitMQ.Client;

class RabbitMqConfig
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
