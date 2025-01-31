
using Ecommerce.ConfigDatabase;
using Ecommerce.Service.MessagePurchansing;
using Ecommerce.Service.Model;
using MongoDB.Driver;

namespace Ecommerce.Service.Persistence.PurchasingProcessPessister;


public class PurchasingProcessService : IPurchasingProcess
{
  private readonly MongoDBContext _db;
  private readonly ICreatePurchansingProcess _createPurchansingProcess;

  public PurchasingProcessService(MongoDBContext db, ICreatePurchansingProcess createPurchansingProcess)
  {
    _db = db;
    _createPurchansingProcess = createPurchansingProcess;
  }

  public async Task<PurchasingProcess> Post(PurchasingProcess entity)
  {
    await _db.GetCollection<PurchasingProcess>("purchasingProcess").InsertOneAsync(entity);
    return entity;
  }

  public async Task<List<PurchasingProcess>> GetAll()
  {
    return await _db.GetCollection<PurchasingProcess>("purchasingProcess").Find(_ => true).ToListAsync();
  }

  public async Task<PurchasingProcess> Update(PurchasingProcess entity)
  {
    return await _db.GetCollection<PurchasingProcess>("purchasingProcess").FindOneAndUpdateAsync(x => x.Id == entity.Id, Builders<PurchasingProcess>.Update.Set(x => x.StatusProcess, "Processing"));
  }
}
