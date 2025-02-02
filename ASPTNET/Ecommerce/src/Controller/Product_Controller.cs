using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence;
using Microsoft.OpenApi.Models;


namespace poc.api.sqlserver.EndPoints;
public static class ProdutosEndpoints
{
  public static void RegisterProdutosEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapGet("/api/produto", async (IProductService _service, ILogger<Program> logger) =>
    {


      var produto = await _service.Get();
      if (produto is null)
      {

        return Results.NotFound();
      }


      return TypedResults.Ok(produto);
    });

    app.MapGet("/api/produto/id", async (HttpRequest request, IProductService _service, ILogger<Program> logger) =>
    {
      var id = request.Query["id"].ToString();


      var produto = await _service.Get(id);
      if (produto is null)
      {

        return Results.NotFound();
      }


      return Results.Ok(produto);
    });


    app.MapPost("/api/produto", async (Product entity, IProductService _service, ILogger<Program> logger) =>
    {

      if (entity is null)
      {

        return Results.NotFound();
      }

      return Results.Created($"{entity.Id}", await _service.Post(entity));
    });

    app.MapPut("/api/produto", async (Product entity, IProductService _service, ILogger<Program> logger) =>
    {

      if (entity is null)
      {

        return Results.NotFound();
      }

      return Results.Ok(await _service.Put(entity));
    });


    app.MapDelete("/api/produto/{id}", async (string id, IProductService _service, ILogger<Program> logger) =>
    {
      var produto = await _service.Delete(id);

      return Results.Ok($"Produto id={id} deletado");
    });

    app.MapGet("/api/produto/getByCategory", async (HttpRequest request, IProductService _service, ILogger<Program> logger) =>
    {
      var category = request.Query["category"];

      if (string.IsNullOrEmpty(category))
      {
        return Results.BadRequest("Category is required");
      }

      var produtos = await _service.GetByCategory(category);
      return Results.Ok(produtos);
    });


    app.MapPost("/api/produto/insertAll", async (List<Product> entity, IProductService _service, ILogger<Program> logger) =>
    {
      var produtos = await _service.PostAll(entity);
      return Results.Ok(produtos);
    });
  }
}
