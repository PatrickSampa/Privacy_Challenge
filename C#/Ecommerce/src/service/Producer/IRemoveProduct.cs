using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;

public interface IRemoveProduct
{
  Task Publish(Product model);
}