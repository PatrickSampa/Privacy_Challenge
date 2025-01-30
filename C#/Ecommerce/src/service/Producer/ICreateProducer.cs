using Ecommerce.Service.Model;

namespace Ecommerce.Service.Producer;

public interface ICreateProducer
{
  Task Publish(Product model);
}