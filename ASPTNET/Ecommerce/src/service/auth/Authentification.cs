namespace Ecommerce.Service.Auth;
using Ecommerce.ConfigDatabase;
using Ecommerce.Model;
using MongoDB.Driver;

//Classe para Simular o login de um usuário, não é uma implementação real
public class Authentification : IAuthentification
{

  private readonly MongoDBContext _db;

  public Authentification(MongoDBContext db)
  {
    _db = db;
  }

  public async Task<User> GetByPassword(string password)
  {
    var user = await _db.GetCollection<User>("users").Find(x => x.Password == password).FirstOrDefaultAsync();
    if (user == null) return null;
    return user;
  }

  public async Task<User> GetUserByEmail(string email)
  {
    var user = await _db.GetCollection<User>("users").Find(x => x.Email == email).FirstOrDefaultAsync();
    if (user == null) return null;
    return user;
  }

  public async Task<User> Login(string email, string password)
  {
    var userByEmail = await GetUserByEmail(email);
    var userByPassword = await GetByPassword(password);
    if (userByEmail == null || userByPassword == null)
    {
      throw new Exception("User Incorrect");
    }

    return userByEmail;
  }
}