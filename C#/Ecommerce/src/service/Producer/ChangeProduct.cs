using System.Text;
using System.Text.Json;
using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;


public class ChangeProduct : IChangeProduct
{
  private readonly IMessageBusService _messageBusService;
  private readonly ILogger<ChangeProduct> _logger;
  private const string QUEUE_NAME = "ALTERAR_PRODUTO";
  public ChangeProduct(IMessageBusService messageBusService, ILogger<ChangeProduct> logger)
  {
    _messageBusService = messageBusService;
    _logger = logger;
  }

  public async Task Publish(Product model)
  {
    _logger.LogInformation($"Producer > Publish > Produto > CHANGE_PRODUCT > ExecuteAsync - SQL Server... {model}");
    var modelJson = JsonSerializer.Serialize(model);
    var modelBytes = Encoding.UTF8.GetBytes(modelJson);
    await _messageBusService.Publish(QUEUE_NAME, modelBytes);
  }


}
