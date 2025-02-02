namespace Ecommerce.src.Infrastructure.Persistence.ProductPersistence;

using Ecommerce.src.Infrastructure.ConfigDatabase;
using Ecommerce.src.Domain.Model;
using MongoDB.Driver;

public class ProductService : IProductService
{
  private readonly MongoDBContext _db;


  public ProductService(MongoDBContext db)
  {
    _db = db;
  }

  public async Task<List<Product>> Get()
       => await _db.GetCollection<Product>("products").Find(_ => true).ToListAsync();

  public async Task<Product> Get(string id)
      => await _db.GetCollection<Product>("products").Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task<Product> Post(Product entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<Product>("products").InsertOneAsync(entity);

    return entity;
  }

  public async Task<Product> Put(Product entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<Product>("products").ReplaceOneAsync(x => x.Id == entity.Id, entity);

    return entity;
  }

  public async Task<Product> Delete(string id)
  {
    var entity = await Get(id);

    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<Product>("products").DeleteOneAsync(x => x.Id == id);

    return entity;
  }

  public async Task<List<Product>> GetByCategory(string category)
      => await _db.GetCollection<Product>("products").Find(x => x.Categoria == category).ToListAsync();

  public async Task<List<Product>> PostAll(List<Product> entity)
  {
    await _db.GetCollection<Product>("products").InsertManyAsync(entity);

    return entity;
  }

}