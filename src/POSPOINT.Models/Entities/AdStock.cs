namespace POSPOINT.Models.Entities;

/// <summary>
/// Tracks advertisement/stock deficit - items that are missing or unaccounted for
/// </summary>
public class AdStock
{
    public int AdStockId { get; set; }
    public string AdStockNumber { get; set; } = string.Empty; // AS-2026-001
    public int StoreId { get; set; }
    public int VariantId { get; set; }
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public int DeficitQuantity { get; set; } // Quantity missing/unaccounted
    public decimal DeficitValue { get; set; } // Cost value of missing items
    public string Reason { get; set; } = string.Empty; // Breakage, Theft, Administrative Error, Evaporation, Expiry, etc.
    public string Category { get; set; } = string.Empty; // Advertisement, Damage, Theft, System Error, Expiry
    public string Status { get; set; } = "Pending"; // Pending, Investigated, Resolved, Closed
    public string? InvestigationNotes { get; set; }
    public int? ReportedByUserId { get; set; }
    public int? InvestigatedByUserId { get; set; }
    public DateTime? InvestigationDate { get; set; }
    public string? ResolutionAction { get; set; } // Write-off, Replacement, Compensation, etc.
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ClosedDate { get; set; }
}
