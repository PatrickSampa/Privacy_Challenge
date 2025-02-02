using System.Text;
using System.Text.Json;
using Ecommerce.src.Domain.Model;


namespace Ecommerce.src.Infrastructure.MessageBus.MessagePurchansing;

public class CreatePurchansingProcess : ICreatePurchansingProcess
{

  private readonly IMessageBusService _messageBusService;
  private readonly ILogger<CreatePurchansingProcess> _logger;
  private const string QUEUE_NAME = "CREATE_PURCHASING_PROCESS";

  public CreatePurchansingProcess(IMessageBusService messageBusService, ILogger<CreatePurchansingProcess> logger)
  {
    _messageBusService = messageBusService;
    _logger = logger;
  }

  public async Task Publish(PurchasingProcess model)
  {
    var purchasingProcessJson = JsonSerializer.Serialize(model);
    var purchasingProcessBytes = Encoding.UTF8.GetBytes(purchasingProcessJson);
    await _messageBusService.Publish(QUEUE_NAME, purchasingProcessBytes);
  }
}