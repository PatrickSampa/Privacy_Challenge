using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence.PurchasingProcessPessister;

namespace Ecommerce.src.Controller;


public static class Purchasing_Controller
{
  public static void RegisterPurchasingEndPoint(this IEndpointRouteBuilder app)
  {
    app.MapGet("/api/purchasing", async (IPurchasingProcess purchasingProcess, ILogger<Program> logger) =>
    {
      var result = await purchasingProcess.GetAll();
      return Results.Ok(result);
    });

    app.MapPut("/api/purchasing/canceled", async (IPurchasingProcess _purchasingProcess, ILogger<Program> logger, PurchasingProcess purchasingProcess) =>
    {

      var result = await _purchasingProcess.Cancel(purchasingProcess);
      return Results.Ok(result);
    });

    app.MapPut("/api/purchasing/sucess", async (IPurchasingProcess _purchasingProcess, ILogger<Program> logger, PurchasingProcess purchasingProcess) =>
    {
      try
      {

        var result = await _purchasingProcess.PaySucessUpdate(purchasingProcess);
        if (result == null)
          return Results.NotFound();

        return Results.Ok(result);
      }
      catch (Exception ex)
      {
        return Results.BadRequest(ex.Message);
      }
    });

    app.MapGet("/api/purchasing/getByIdBuy", async (HttpContext http, IPurchasingProcess _purchasingProcess, ILogger<Program> logger) =>
    {
      var id = http.Request.Query["id"].ToString();
      var result = await _purchasingProcess.getByIdBuyProduct(id);
      return Results.Ok(result);
    });
  }




}

