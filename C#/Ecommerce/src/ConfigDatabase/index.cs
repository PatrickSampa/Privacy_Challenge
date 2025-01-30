namespace Ecommerce.ConfigDatabase;

using Ecommerce.Model;
using Ecommerce.Service.Model;
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBContext
{
  private readonly IMongoDatabase _database;

  public MongoDBContext(IMongoDatabase database)
  {
    _database = database;
  }
  public IMongoCollection<T> GetCollection<T>(string collectionName)
  {
    return _database.GetCollection<T>(collectionName);
  }

  public void Initialize()
  {
    Console.WriteLine("Inicializando banco de dados...");
    CreateCollectionIfNotExists<Product>("products");
    CreateCollectionIfNotExists<PurchasingProcess>("purchasingprocess");
    CreateCollectionIfNotExists<BuyProduct>("buyproducts");
    CreateCollectionIfNotExists<User>("users");
  }

  private void CreateCollectionIfNotExists<TDocument>(string collectionName)
  {
    var filter = new BsonDocument("name", collectionName);
    var collections = _database.ListCollections(new ListCollectionsOptions { Filter = filter });
    Console.WriteLine($"Coleção {collectionName} criada com sucesso.");
    if (!collections.Any())
    {
      _database.CreateCollection(collectionName);
    }
    else
    {
      Console.WriteLine($"Coleção {collectionName} já existe.");
    }
  }
}