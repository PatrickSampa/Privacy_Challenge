using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.MessageBus.MessagePurchansing;

public interface ICreatePurchansingProcess
{
  Task Publish(PurchasingProcess model);
}