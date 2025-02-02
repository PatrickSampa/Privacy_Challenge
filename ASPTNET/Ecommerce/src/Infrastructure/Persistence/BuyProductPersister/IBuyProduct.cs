using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.Persistence.BuyProductPersister;

public interface IBuyProduct
{
  Task<BuyProductModel> Post(BuyProductModel entity);

  Task<BuyProductModel> Update(BuyProductModel entity);

  Task<List<BuyProductModel>> GetAll(string id);

  Task<BuyProductModel> GetById(string id);
}
