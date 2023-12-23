var hostName = "localhost";

using var connection = RabbitMqConfig.CreateConnection(hostName);
using var channel = RabbitMqConfig.CreateChannel(connection);
var publisher = new RabbitMqPublisher(channel);

while (true)
{
    Console.Write("Digite a mensagem (ou 'exit' para sair): ");
    var message = Console.ReadLine();

    if (message!.ToLower() == "exit")
        break;

    publisher.PublishMessage(message);
}
