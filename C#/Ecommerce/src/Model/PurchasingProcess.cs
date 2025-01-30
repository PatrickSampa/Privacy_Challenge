namespace Ecommerce.Service.Model;

public class PurchasingProcess
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string Nome { get; set; } = string.Empty;
  public decimal Preco { get; set; }

  public string Descricao { get; set; } = string.Empty;

  public string Categoria { get; set; } = string.Empty;

  public int Quantidade { get; set; }

  public DateTime DataCadastro { get; set; }

  public DateTime DataUpdate { get; set; }
}