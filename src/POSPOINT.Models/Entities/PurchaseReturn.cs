namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents a purchase return/debit note to a supplier
/// </summary>
public class PurchaseReturn
{
    public int PurchaseReturnId { get; set; }
    public string PRNumber { get; set; } = string.Empty; // PR-2026-001
    public int PurchaseOrderId { get; set; } // Reference to original PO
    public int? SupplierId { get; set; }
    public int StoreId { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.Now;
    public string ReturnReason { get; set; } = string.Empty; // Defective, Damaged, Wrong Item, Quantity Mismatch, etc.
    public decimal TotalQuantity { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Received by Supplier
    public string? Notes { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int? ApprovedByUserId { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? DocumentPath { get; set; } // Path to debit note PDF
}
