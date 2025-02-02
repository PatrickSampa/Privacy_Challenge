using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.Persistence.ProcessPersistencer;

public interface IProcessProduct
{
  Task<List<PurchasingProcess>> Get();
  Task<PurchasingProcess> Get(string id);
  Task<PurchasingProcess> Post(PurchasingProcess entity);
  Task<PurchasingProcess> Put(PurchasingProcess entity);
  Task<PurchasingProcess> Delete(string id);
}