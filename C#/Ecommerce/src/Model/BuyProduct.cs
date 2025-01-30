namespace Ecommerce.Service.Model;

public class BuyProduct
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public int ProductId { get; set; }
  public int Quantity { get; set; }

  public decimal TotalPrice { get; set; }

  public bool PaymentCompleted { get; set; }

  public DateTime DateBuy { get; set; }
}