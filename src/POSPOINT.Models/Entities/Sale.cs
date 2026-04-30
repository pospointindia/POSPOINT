namespace POSPOINT.Models.Entities;

public class Sale
{
    public int SaleId { get; set; }
    public int StoreId { get; set; }
    public int UserId { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, UPI
    public string? ReferenceNumber { get; set; }
}
