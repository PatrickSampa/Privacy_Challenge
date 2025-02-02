using RabbitMQ.Client;

namespace Ecommerce.src.Infrastructure.MessageBus;
public class MessageBusService : IMessageBusService
{
  private readonly ConnectionFactory _connectionFactory;
  private readonly IConfiguration _configuration;
  private readonly ILogger<MessageBusService> _logger;

  public MessageBusService(IConfiguration configuration, ILogger<MessageBusService> logger)
  {
    _configuration = configuration;
    _connectionFactory = new ConnectionFactory
    {
      HostName = _configuration["RabbitMQ__HostName"] ?? "rabbitmq", // Nome do serviço no docker-compose
      UserName = _configuration["RabbitMQ__UserName"] ?? "guest",
      Password = _configuration["RabbitMQ__Password"] ?? "guest"
    };
    _logger = logger;
  }
  public async Task Publish(string queue, byte[] message)
  {
    try
    {
      using (var connection = await _connectionFactory.CreateConnectionAsync())
      {
        _logger.LogInformation("Conexão com RabbitMQ estabelecida.");
        using (var channel = await connection.CreateChannelAsync())
        {
          _logger.LogInformation("Canal criado. Preparando para declarar a fila.");
          await channel.QueueDeclareAsync(
              queue: queue,
              durable: true,
              exclusive: false,
              autoDelete: false,
              arguments: null);
          _logger.LogInformation("Fila {QueueName} declarada com sucesso.", queue);

          await channel.BasicPublishAsync(
              exchange: "",
              routingKey: queue,
              mandatory: false,
              body: new ReadOnlyMemory<byte>(message));
          _logger.LogInformation("Mensagem publicada na fila {QueueName}.", queue);
        }
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Falha ao conectar ou enviar mensagem ao RabbitMQ.");
    }
  }
}