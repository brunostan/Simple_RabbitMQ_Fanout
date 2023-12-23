using RabbitMQ.Client;
using RabbitMQ.Client.Events;

class Subscriber
{
    private readonly IModel _channel;

    public Subscriber(IModel channel)
    {
        _channel = channel;
    }

    public void ConfigureRabbitMq(string exchangeName, string queueName)
    {
        _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

        _channel.QueueDeclare(queue: queueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        _channel.QueueBind(queue: queueName,
                          exchange: exchangeName,
                          routingKey: "");
    }

    public void StartListening(string queueName, IMessageHandler messageHandler)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, ea) => messageHandler.HandleMessage(model!, ea);

        _channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);
    }
}
