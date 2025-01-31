namespace Ecommerce.Service.Model;

public class BuyProductModel
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string UserId { get; set; } = string.Empty;
  public string ProductId { get; set; } = string.Empty;
  public int Quantity { get; set; }

  public decimal PriceTotal { get; set; } = decimal.Zero;

  public bool PaymentCompleted { get; set; }

  public DateTime DateCreatedBuy { get; set; }

  public DateTime DateUpdatedBuy { get; set; }
}