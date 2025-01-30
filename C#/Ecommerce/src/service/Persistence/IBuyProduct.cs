using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;

public interface IBuyProduct
{
  Task<BuyProduct> Post(BuyProduct entity);
}
