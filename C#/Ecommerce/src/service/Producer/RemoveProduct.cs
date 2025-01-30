using System.Text;
using System.Text.Json;
using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;


public class RemoveProduct : IRemoveProduct
{
  private readonly IMessageBusService _messageBusService;
  private readonly ILogger<RemoveProduct> _logger;
  private const string QUEUE_NAME = "REMOVE_PRODUCT";
  public RemoveProduct(IMessageBusService messageBusService, ILogger<RemoveProduct> logger)
  {
    _messageBusService = messageBusService;
    _logger = logger;
  }

  public async Task Publish(Product model)
  {
    _logger.LogInformation($"Producer > Publish > Produto > REMOVE_PRODUCT > ExecuteAsync - SQL Server... {model}");
    var modelJson = JsonSerializer.Serialize(model);
    var modelBytes = Encoding.UTF8.GetBytes(modelJson);
    await _messageBusService.Publish(QUEUE_NAME, modelBytes);
  }
}