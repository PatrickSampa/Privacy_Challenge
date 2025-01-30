using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;

public interface IProcessProduct
{
  Task<List<PurchasingProcess>> Get();
  Task<PurchasingProcess> Get(int id);
  Task<PurchasingProcess> Post(PurchasingProcess entity);
  Task<PurchasingProcess> Put(PurchasingProcess entity);
  Task<PurchasingProcess> Delete(int id);
}