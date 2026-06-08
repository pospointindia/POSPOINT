namespace POSPOINT.Models.Entities;

/// <summary>
/// Represents a sale return/credit note from a customer
/// </summary>
public class SaleReturn
{
    public int SaleReturnId { get; set; }
    public string SRNumber { get; set; } = string.Empty; // SR-2026-001
    public int SaleId { get; set; } // Reference to original Sale
    public int StoreId { get; set; }
    public int? CustomerId { get; set; } // If customer is tracked
    public DateTime ReturnDate { get; set; } = DateTime.Now;
    public string ReturnReason { get; set; } = string.Empty; // Defective, Not as described, Changed mind, Damaged, Wrong item, etc.
    public decimal TotalQuantity { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string RefundMethod { get; set; } = "Cash"; // Cash, Card, Store Credit, Original Payment Method
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Refunded
    public string? Notes { get; set; }
    public int? ProcessedByUserId { get; set; }
    public DateTime? ProcessedDate { get; set; }
    public int? ApprovedByUserId { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public decimal? RefundAmount { get; set; }
    public DateTime? RefundDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
