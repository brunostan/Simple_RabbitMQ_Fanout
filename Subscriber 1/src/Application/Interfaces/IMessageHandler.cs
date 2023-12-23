using RabbitMQ.Client.Events;

interface IMessageHandler
{
    void HandleMessage(object model, BasicDeliverEventArgs ea);
}
