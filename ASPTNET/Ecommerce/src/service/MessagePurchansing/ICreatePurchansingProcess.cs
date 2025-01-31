using Ecommerce.Service.Model;

namespace Ecommerce.Service.MessagePurchansing;

public interface ICreatePurchansingProcess
{
  Task Publish(PurchasingProcess model);
}