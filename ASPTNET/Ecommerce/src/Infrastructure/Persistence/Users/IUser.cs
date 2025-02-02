using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.Persistence.Users;

public interface IUser
{
  Task<User> Post(User entity);
  Task<User> GetUserById(string id);

  Task<User> Put(User entity);
  Task<User> Delete(string id);

  Task<List<User>> GetAll();
}

