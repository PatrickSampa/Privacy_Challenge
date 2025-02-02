
using Ecommerce.src.Domain.Model;
using Ecommerce.src.Infrastructure.Persistence.Users;

namespace Ecommerce.src.Presentation.Controller;

public static class Users_Controller
{
  public static void RegisterUsersEndpoints(this IEndpointRouteBuilder app)
  {

    app.MapGet("/api/users/{id}", async (IUser _service, ILogger<Program> logger, string id) =>
    {
      logger.LogInformation("Buscando usuário por ID - MongoDB...");
      var user = await _service.GetUserById(id);
      return TypedResults.Ok(user);
    });

    app.MapPost("/api/users", async (IUser _service, ILogger<Program> logger, User user) =>
    {
      logger.LogInformation("Criando usuário - MongoDB...");
      try
      {
        var newUser = await _service.Post(user);
        return TypedResults.Created($"/api/users/{newUser.Id}", newUser) as IResult;
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message);
        return TypedResults.BadRequest(ex.Message) as IResult;
      }
    });

    app.MapPut("/api/users/{id}", async (IUser _service, ILogger<Program> logger, string id, User user) =>
    {
      logger.LogInformation("Atualizando usuário - MongoDB...");
      var updatedUser = await _service.Put(user);
      return TypedResults.Ok(updatedUser);
    });
    app.MapDelete("/api/users/{id}", async (IUser _service, ILogger<Program> logger, string id) =>
    {
      logger.LogInformation("Deletando usuário - MongoDB...");
      var deletedUser = await _service.Delete(id);
      return TypedResults.NoContent();
    });

  }
}