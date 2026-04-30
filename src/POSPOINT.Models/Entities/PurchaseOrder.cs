namespace POSPOINT.Models.Entities;

public class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public int? SupplierId { get; set; }
    public DateTime PODate { get; set; } = DateTime.Now;
    public DateTime? DeliveryDate { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Partial, Received, Cancelled
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
