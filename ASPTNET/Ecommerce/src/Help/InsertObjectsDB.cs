
using Ecommerce.src._DBObjects;
using Ecommerce.src.Infrastructure.Persistence.ProductPersistence;
using Ecommerce.src.Infrastructure.Persistence.Users;



public class InsertObjectsDB
{
  private readonly ILogger<InsertObjectsDB> _logger;
  private readonly IServiceProvider _serviceProvider;

  public InsertObjectsDB(ILogger<InsertObjectsDB> logger, IServiceProvider serviceProvider)
  {
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  public async Task ExecuteTask()
  {


    // Criar um escopo para resolver as dependências
    using (var scope = _serviceProvider.CreateScope())
    {
      _logger.LogInformation("Executando tarefa periódica. 1");
      var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
      var userService = scope.ServiceProvider.GetRequiredService<IUser>();

      var allProductos = await productService.Get();

      if (allProductos.Count() == 0 || allProductos == null)
      {
        var manyProducts = new Products_DB().InsertDatabaseProducts();
        await productService.PostAll(manyProducts);
      }

      var allUsers = await userService.GetAll();
      if (allUsers.Count() == 0 || allUsers == null)
      {
        var manyUsers = new Products_DB().InsertDatabaseUsers();
        await userService.Post(manyUsers);
      }



    }
  }
}