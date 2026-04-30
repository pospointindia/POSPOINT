namespace POSPOINT.Models.Entities;

public class PurchaseOrderItem
{
    public int PurchaseOrderItemId { get; set; }
    public int PurchaseOrderId { get; set; }
    public int VariantId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
    public int ReceivedQuantity { get; set; } = 0;
    public DateTime? ReceivedDate { get; set; }
}
