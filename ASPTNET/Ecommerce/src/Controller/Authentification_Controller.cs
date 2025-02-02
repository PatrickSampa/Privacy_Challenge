using Ecommerce.Service.Auth;

namespace Ecommerce.Controller;

public static class Authentification_Controller
{

  public static void RegisterAuthentificationEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/login", async (IAuthentification _service, ILogger<Program> logger, ObjectLogin login) =>
    {
      logger.LogInformation("Logando usuário - MongoDB...");
      try
      {
        var loginUser = await _service.Login(login.Email, login.Password);
        return TypedResults.Ok(loginUser);
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message);
        return Results.BadRequest(ex.Message);
      }
    });
  }
}