namespace Ecommerce.src.Domain.Model;

public class User
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}