namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents individual items in a stock transfer
/// </summary>
public class StockTransferItem
{
    public int StockTransferItemId { get; set; }
    public int StockTransferId { get; set; }
    public int VariantId { get; set; }
    public int QuantityTransferred { get; set; }
    public int? QuantityReceived { get; set; }
    public int? QuantityDamaged { get; set; }
    public int? QuantityMissing { get; set; }
    public string? Remarks { get; set; }
    public string? BatchNumber { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
