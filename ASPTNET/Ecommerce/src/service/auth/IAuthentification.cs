using Ecommerce.Model;

namespace Ecommerce.Service.Auth
{
  public interface IAuthentification
  {
    Task<User> Login(string email, string password);

    Task<User> GetUserByEmail(string email);

    Task<User> GetByPassword(string password);
  }
}