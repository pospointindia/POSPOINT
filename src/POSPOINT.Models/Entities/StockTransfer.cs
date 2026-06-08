namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents stock transfer between stores
/// </summary>
public class StockTransfer
{
    public int StockTransferId { get; set; }
    public string TransferNumber { get; set; } = string.Empty; // ST-2026-001
    public int FromStoreId { get; set; } // Source store
    public int ToStoreId { get; set; } // Destination store
    public DateTime TransferDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Pending"; // Pending, Dispatched, InTransit, Received, Cancelled
    public string? TransporterId { get; set; } // Reference to transporter
    public string? TrackingNumber { get; set; }
    public DateTime? DispatchedDate { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public string? Notes { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int? ReceivedByUserId { get; set; }
    public DateTime? CancelledDate { get; set; }
    public string? CancellationReason { get; set; }
    public decimal TransportCost { get; set; }
}
