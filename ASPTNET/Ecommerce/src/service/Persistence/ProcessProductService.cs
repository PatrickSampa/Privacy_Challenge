namespace Ecommerce.Service.Persistence;

using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;
using MongoDB.Driver;

public class ProcessProductService : IProcessProduct
{
  private readonly MongoDBContext _db;


  public ProcessProductService(MongoDBContext db)
  {
    _db = db;
  }

  public async Task<List<PurchasingProcess>> Get()
       => await _db.GetCollection<PurchasingProcess>("purchasingprocess").Find(_ => true).ToListAsync();

  public async Task<PurchasingProcess> Get(string id)
      => await _db.GetCollection<PurchasingProcess>("purchasingprocess").Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task<PurchasingProcess> Post(PurchasingProcess entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<PurchasingProcess>("purchasingprocess").InsertOneAsync(entity);

    return entity;
  }

  public async Task<PurchasingProcess> Put(PurchasingProcess entity)
  {
    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<PurchasingProcess>("purchasingprocess").ReplaceOneAsync(x => x.Id == entity.Id, entity);

    return entity;
  }

  public async Task<PurchasingProcess> Delete(string id)
  {
    var entity = await Get(id);

    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<PurchasingProcess>("purchasingprocess").DeleteOneAsync(x => x.Id == id);

    return entity;
  }
}
