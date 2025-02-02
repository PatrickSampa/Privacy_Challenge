namespace Ecommerce.Service.Persistence.PurchasingProcessPessister;
using Ecommerce.Service.Model;

public interface IPurchasingProcess
{
  Task<PurchasingProcess> Post(PurchasingProcess entity);
  Task<List<PurchasingProcess>> GetAll();

  Task<PurchasingProcess> GetById(string id);

  Task<PurchasingProcess> Cancel(PurchasingProcess entity);

  Task<PurchasingProcess> PaySucessUpdate(PurchasingProcess entity);

  Task<PurchasingProcess> Update(PurchasingProcess entity);

  Task<PurchasingProcess> getByIdBuyProduct(string id);

}
