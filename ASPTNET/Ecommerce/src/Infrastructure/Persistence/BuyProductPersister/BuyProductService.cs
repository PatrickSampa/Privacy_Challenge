using Ecommerce.src.Infrastructure.ConfigDatabase;
using Ecommerce.src.Domain.Model;
using Ecommerce.src.Infrastructure.Persistence.ProductPersistence;
using Ecommerce.src.Infrastructure.Persistence.PurchasingProcessPessister;
namespace Ecommerce.src.Infrastructure.Persistence.BuyProductPersister;
using MongoDB.Driver;


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

  public async Task<List<BuyProductModel>> GetAll(string id)
  => await _db.GetCollection<BuyProductModel>("buyProduct").Find(x => x.UserId == id).ToListAsync();

  public async Task<BuyProductModel> GetById(string id)
  {
    return await _db.GetCollection<BuyProductModel>("buyProduct").Find(x => x.Id == id).FirstOrDefaultAsync();
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

      var newEntity = new PurchasingProcess(entity.UserId, entity.Id);


      await _purchasingProcess.Post(newEntity);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }

    return entity;
  }

  public async Task<BuyProductModel> Update(BuyProductModel entity)
  {

    await _db.GetCollection<BuyProductModel>("buyProduct").ReplaceOneAsync(x => x.Id == entity.Id, entity);
    return entity;
  }
}

