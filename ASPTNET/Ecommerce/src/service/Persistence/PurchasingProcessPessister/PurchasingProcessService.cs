
using Ecommerce.ConfigDatabase;
using Ecommerce.Service.Model;
using MongoDB.Driver;

namespace Ecommerce.Service.Persistence.PurchasingProcessPessister;


public class PurchasingProcessService : IPurchasingProcess
{
  private readonly MongoDBContext _db;



  public PurchasingProcessService(MongoDBContext db)
  {
    _db = db;


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

  public async Task<PurchasingProcess> Cancel(PurchasingProcess entity)
  {
    Console.WriteLine("Entrou aquiiii");
    Console.WriteLine(entity);
    var statusEntity = await this.GetById(entity.Id);
    if (statusEntity.StatusProcess == "Success") throw new Exception("Payment already approved, Cancellation unavailable");
    entity.StatusProcess = "Canceled";
    await _db.GetCollection<PurchasingProcess>("purchasingProcess").ReplaceOneAsync(x => x.Id == entity.Id, entity);

    return entity;
  }

  public async Task<PurchasingProcess> GetById(string id)
  {
    return await _db.GetCollection<PurchasingProcess>("purchasingProcess").Find(x => x.Id == id).FirstOrDefaultAsync();
  }

  public async Task<PurchasingProcess> Update(PurchasingProcess entity)
  {
    await _db.GetCollection<PurchasingProcess>("purchasingProcess").ReplaceOneAsync(x => x.Id == entity.Id, entity);
    return entity;
  }

  public async Task<PurchasingProcess> PaySucessUpdate(PurchasingProcess entity)
  {
    var statusEntity = await this.GetById(entity.Id);
    if (statusEntity.StatusProcess == "Canceled")
    {
      return statusEntity;
    }
    await _db.GetCollection<PurchasingProcess>("purchasingProcess").ReplaceOneAsync(x => x.Id == entity.Id, entity);

    return entity;
  }

  public async Task<PurchasingProcess> getByIdBuyProduct(string id)
  {
    return await _db.GetCollection<PurchasingProcess>("purchasingProcess").Find(x => x.IdBuyProduct == id).FirstOrDefaultAsync();
  }
}
