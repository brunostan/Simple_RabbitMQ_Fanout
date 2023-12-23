using RabbitMQ.Client;

class Program
{
    static void Main()
    {
        var hostName = "localhost"; // Altere conforme necessário
        var exchangeName = "fanout_exchange";
        var queueName = "shared_queue";

        using var connection = new ConnectionFactory() { HostName = hostName }.CreateConnection();
        using var channel = connection.CreateModel();

        var subscriber = new Subscriber(channel);
        var messageHandler = new MessageHandler();

        subscriber.ConfigureRabbitMq(exchangeName, queueName);
        subscriber.StartListening(queueName, messageHandler);

        Console.WriteLine("Aguardando mensagens. Pressione [Enter] para sair.");
        Console.ReadLine();
    }
}
