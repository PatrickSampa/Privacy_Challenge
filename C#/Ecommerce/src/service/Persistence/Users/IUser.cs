using Ecommerce.Model;

namespace Ecommerce.Service.Persistence.Users;

public interface IUser
{
  Task<User> Post(User entity);
  Task<User> GetUserById(string id);

  Task<User> Put(User entity);
  Task<User> Delete(string id);
}