using Ecommerce.Service.Model;

namespace Ecommerce.Service.Persistence;

public interface IProductService
{
  Task<List<Product>> Get();
  Task<Product> Get(string id);
  Task<Product> Post(Product entity);
  Task<Product> Put(Product entity);
  Task<Product> Delete(string id);
}