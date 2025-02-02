using Ecommerce.src.Domain.Model;

namespace Ecommerce.src.Infrastructure.Persistence.ProductPersistence;

public interface IProductService
{
  Task<List<Product>> Get();
  Task<Product> Get(string id);
  Task<Product> Post(Product entity);
  Task<Product> Put(Product entity);
  Task<Product> Delete(string id);

  Task<List<Product>> PostAll(List<Product> entity);

  Task<List<Product>> GetByCategory(string category);


}