using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence;
using MongoDB.Driver;


namespace Ecommerce.Service.Orchestrator;



public class PurchaseOrchestrator : IPurchaseOrchestrator
{
  private readonly MongoDBContext _db;
  private readonly IBuyProduct _buyProduct;

  public PurchaseOrchestrator(MongoDBContext db, IBuyProduct buyProduct)
  {
    _db = db;
    _buyProduct = buyProduct;
  }

  public async Task<BuyProductModel> Cancel(string id)
  {
    var buyProduct = await _buyProduct.GetById(id);
    buyProduct.PaymentCompleted = false;
    await _buyProduct.Update(buyProduct);
    return buyProduct;
  }

  public async Task<BuyProductModel> PaySucessUpdate(string id)
  {
    var buyProduct = await _buyProduct.GetById(id);
    buyProduct.PaymentCompleted = true;
    await _buyProduct.Update(buyProduct);
    return buyProduct;
  }
}

