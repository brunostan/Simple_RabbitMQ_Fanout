using RabbitMQ.Client;

class RabbitMqPublisher
{
    private const string ExchangeName = "fanout_exchange";

    private readonly IModel _channel;

    public RabbitMqPublisher(IModel channel)
    {
        _channel = channel;
        ConfigureRabbitMq();
    }

    private void ConfigureRabbitMq()
    {
        _channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout);
    }

    public void PublishMessage(string message)
    {
        var body = System.Text.Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(ExchangeName, "", null, body);
        Console.WriteLine($"[x] Mensagem enviada: {message}");
    }
}
