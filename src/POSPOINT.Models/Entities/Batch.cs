namespace POSPOINT.Models.Entities;

public class Batch
{
    public int BatchId { get; set; }
    public int ProductId { get; set; }
    public string BatchNumber { get; set; } = string.Empty;
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public bool IsExpired { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
