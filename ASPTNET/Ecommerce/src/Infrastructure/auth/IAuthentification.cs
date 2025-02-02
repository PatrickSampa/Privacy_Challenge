using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.auth
{
  public interface IAuthentification
  {
    Task<User> Login(string email, string password);

    Task<User> GetUserByEmail(string email);

    Task<User> GetByPassword(string password);
  }
}