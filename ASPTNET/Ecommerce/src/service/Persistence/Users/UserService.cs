using Ecommerce.ConfigDatabase;
using Ecommerce.Model;
using MongoDB.Driver;

namespace Ecommerce.Service.Persistence.Users;


public class UserService : IUser
{
  private readonly MongoDBContext _db;

  public UserService(MongoDBContext db)
  {
    _db = db;
  }

  public async Task<User> Post(User entity)
  {
    var user = await _db.GetCollection<User>("users").Find(x => x.Email == entity.Email).FirstOrDefaultAsync();
    if (user is not null) throw new Exception("user already exists");
    await _db.GetCollection<User>("users").InsertOneAsync(entity);
    return entity;
  }


  public async Task<User> GetUserById(string id)
   => await _db.GetCollection<User>("users").Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task<User> Put(User entity)
  {
    await _db.GetCollection<User>("users").ReplaceOneAsync(x => x.Id == entity.Id, entity);
    return entity;
  }

  public async Task<User> Delete(string id)
  {
    var entity = await GetUserById(id);

    if (entity is null)
      throw new ArgumentNullException(nameof(entity));

    await _db.GetCollection<User>("users").DeleteOneAsync(x => x.Id == id);
    return entity;
  }
}