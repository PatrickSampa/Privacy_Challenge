using RabbitMQ.Client;

namespace poc.api.sqlserver.Service.MessageBus;
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
      HostName = _configuration["RabbitMQConnection:Host"] ?? throw new Exception("RabbitMQConnection:Host not found"),
      UserName = _configuration["RabbitMQConnection:Username"] ?? throw new Exception("RabbitMQConnection:Username not found"),
      Password = _configuration["RabbitMQConnection:Password"] ?? throw new Exception("RabbitMQConnection:Password not found")
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