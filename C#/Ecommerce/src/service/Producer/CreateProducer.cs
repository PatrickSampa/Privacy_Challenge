using System.Text;
using System.Text.Json;
using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;

public class CreateProducer : ICreateProducer
{

  private readonly IMessageBusService _messageBusService;
  private readonly ILogger<CreateProducer> _logger;
  private const string QUEUE_NAME = "CREATE_PRODUCT";


  public CreateProducer(IMessageBusService messageBusService, ILogger<CreateProducer> logger)
  {
    _messageBusService = messageBusService;
    _logger = logger;
  }

  public async Task Publish(Product model)
  {
    _logger.LogInformation($"Producer > Publish > Produto > CREATE_PRODUCT > ExecuteAsync - SQL Server... {model}");
    var productJson = JsonSerializer.Serialize(model);
    var productBytes = Encoding.UTF8.GetBytes(productJson);
    await _messageBusService.Publish(QUEUE_NAME, productBytes);
  }
}