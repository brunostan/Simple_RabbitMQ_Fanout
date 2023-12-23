# Simple RabbitMQ Fanout

Este é um exemplo simples de como usar o RabbitMQ com uma Exchange do tipo Fanout, uma Queue única e dois Consumers operando em Round-robin.

## Pré-requisitos

Use o arquivo "Docker/docker-compose.yml" para configurar uma imagem do RabbitMQ + Alphine.

- O projeto está configurado para iniciar primeiro os consumers e posteriormente o publisher.
- Use o terminal do publisher para enviar as mensagens e confira o balanceamento acontecendo nos outros dois terminais dos consumers.
- Não esqueça de conferir o gerenciador do RabbitMQ.
