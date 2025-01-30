using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;


public interface IChangeProduct
{
  Task Publish(Product model);
}