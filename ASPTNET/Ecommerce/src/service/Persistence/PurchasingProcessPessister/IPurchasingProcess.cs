namespace Ecommerce.Service.Persistence.PurchasingProcessPessister;
using Ecommerce.Service.Model;

public interface IPurchasingProcess
{
  Task<PurchasingProcess> Post(PurchasingProcess entity);
  Task<List<PurchasingProcess>> GetAll();

  Task<PurchasingProcess> Update(PurchasingProcess entity);
}
