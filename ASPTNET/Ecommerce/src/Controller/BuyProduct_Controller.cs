using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence;

namespace Ecommerce.Controller;

public static class BuyProduct_Controller
{

  public static void RegisterBuyProductEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapPost("/api/buy", async (BuyProductModel entity, IBuyProduct _service, ILogger<Program> logger) =>
    {
      logger.LogInformation("Compra de produto - SQL Server...");

      if (entity is null)
      {
        logger.LogWarning("Objeto Vazio - SQL Server");
        return Results.NotFound();
      }

      return Results.Created($"{entity.Id}", await _service.Post(entity));
    });
  }

}