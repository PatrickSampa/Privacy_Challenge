using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence.PurchasingProcessPessister;

namespace Ecommerce.Service.Persistence;


public class BuyProductService : IBuyProduct
{
  private readonly MongoDBContext _db;
  private readonly IPurchasingProcess _purchasingProcess;
  private readonly IProductService _productService;

  public BuyProductService(MongoDBContext db, IPurchasingProcess purchasingProcessParam, IProductService productService)
  {
    _db = db;
    _purchasingProcess = purchasingProcessParam;
    _productService = productService;
  }

  public async Task<BuyProductModel> Post(BuyProductModel entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    try
    {
      var product = await _productService.Get(entity.ProductId);

      if (product is null)
        throw new Exception("Product not found");

      entity.PriceTotal = product.Preco * entity.Quantity;
      entity.PaymentCompleted = false;

      await _db.GetCollection<BuyProductModel>("buyProduct").InsertOneAsync(entity);

      var newEntity = new PurchasingProcess(entity.UserId, entity.ProductId);


      await _purchasingProcess.Post(newEntity);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }

    return entity;
  }
}