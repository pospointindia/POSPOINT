namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents individual items in a sale return
/// </summary>
public class SaleReturnItem
{
    public int SaleReturnItemId { get; set; }
    public int SaleReturnId { get; set; }
    public int ProductId { get; set; }
    public int ReturnQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
    public string? DefectDescription { get; set; }
    public string? SerialNumber { get; set; }
    public string? BatchNumber { get; set; }
}
