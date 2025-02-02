

namespace Ecommerce.Service.Model;

public class PurchasingProcess
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string UserId { get; set; } = string.Empty;

  public string IdBuyProduct { get; set; } = string.Empty;

  public string StatusProcess { get; set; } = string.Empty;


  public DateTime DataCadastro { get; set; }

  public DateTime DataUpdate { get; set; }


  public PurchasingProcess(string _userId, string _idBuyProduct)
  {
    Id = Guid.NewGuid().ToString();
    UserId = _userId;
    IdBuyProduct = _idBuyProduct;
    StatusProcess = "waitingInLine";
    DataCadastro = DateTime.UtcNow;
    DataUpdate = DateTime.UtcNow;
  }
  public PurchasingProcess()
  {
  }


}