using RabbitMQ.Client.Events;

class MessageHandler : IMessageHandler
{
    public void HandleMessage(object model, BasicDeliverEventArgs ea)
    {
        var body = ea.Body.ToArray();
        var message = System.Text.Encoding.UTF8.GetString(body);
        Console.WriteLine($"[x] Consumer 2 received: {message}");
    }
}
