using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;

public interface IBuyProduct
{
  Task<BuyProductModel> Post(BuyProductModel entity);
}
