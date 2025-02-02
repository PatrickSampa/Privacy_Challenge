using Ecommerce.src.Domain.Model;
using Ecommerce.src.Infrastructure.Persistence.BuyProductPersister;

namespace Ecommerce.src.Presentation.Controller;

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

    app.MapGet("/api/buy/all", async (HttpRequest request, IBuyProduct _service, ILogger<Program> logger) =>
    {
      var id = request.Query["id"].ToString();
      logger.LogInformation("Compra de produto - SQL Server...");
      return Results.Ok(await _service.GetAll(id));
    });
  }

}