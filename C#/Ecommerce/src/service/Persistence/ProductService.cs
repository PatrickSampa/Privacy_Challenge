namespace Ecommerce.Service.Persistence;

using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;
using Ecommerce.Service.Producer;
using MongoDB.Driver;

public class ProductService : IProductService
{
  private readonly MongoDBContext _db;
  private readonly ICreateProducer _createProducer;
  private readonly IChangeProduct _changeProduct;
  private readonly IRemoveProduct _removeProduct;

  public ProductService(MongoDBContext db, ICreateProducer createProducer, IChangeProduct changeProduct, IRemoveProduct removeProduct)
  {
    _db = db;
    _createProducer = createProducer;
    _changeProduct = changeProduct;
    _removeProduct = removeProduct;
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
    /*  await _createProducer.Publish(entity); */

    return entity;
  }

  public async Task<Product> Put(Product entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<Product>("products").ReplaceOneAsync(x => x.Id == entity.Id, entity);
    await _changeProduct.Publish(entity);

    return entity;
  }

  public async Task<Product> Delete(string id)
  {
    var entity = await Get(id);

    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<Product>("products").DeleteOneAsync(x => x.Id == id);
    await _removeProduct.Publish(entity);

    return entity;
  }
}
