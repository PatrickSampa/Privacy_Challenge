using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;


public class BuyProductService : IBuyProduct
{
  private readonly MongoDBContext _db;

  public BuyProductService(MongoDBContext db)
  {
    _db = db;
  }

  public async Task<BuyProduct> Post(BuyProduct entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<BuyProduct>("buyProduct").InsertOneAsync(entity);

    return entity;
  }
}