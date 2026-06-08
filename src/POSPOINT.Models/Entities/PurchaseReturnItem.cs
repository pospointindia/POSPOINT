namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents individual items in a purchase return
/// </summary>
public class PurchaseReturnItem
{
    public int PurchaseReturnItemId { get; set; }
    public int PurchaseReturnId { get; set; }
    public int VariantId { get; set; }
    public int ReturnQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
    public string? DefectDescription { get; set; }
    public string? BatchNumber { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
