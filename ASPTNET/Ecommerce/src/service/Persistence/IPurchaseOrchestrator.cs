using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;

public interface IPurchaseOrchestrator
{
  Task<BuyProductModel> PaySucessUpdate(string id);
  Task<BuyProductModel> Cancel(string id);

}