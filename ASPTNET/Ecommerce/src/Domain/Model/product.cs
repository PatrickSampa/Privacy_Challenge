namespace Ecommerce.src.Domain.Model;

public class Product
{
  public string Id { get; set; } = Guid.NewGuid().ToString();

  public string Nome { get; set; } = string.Empty;
  public decimal Preco { get; set; }

  public string Descricao { get; set; } = string.Empty;

  public string Categoria { get; set; } = string.Empty;

  public int Quantidade { get; set; }

}