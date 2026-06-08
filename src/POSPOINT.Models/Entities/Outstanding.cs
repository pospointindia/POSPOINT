namespace POSPOINT.Models.Entities;

/// <summary>
/// Tracks outstanding receivables (customer dues) and payables (supplier dues)
/// </summary>
public class Outstanding
{
    public int OutstandingId { get; set; }
    public int StoreId { get; set; }
    public string Type { get; set; } = string.Empty; // "Receivable" (Customer) or "Payable" (Supplier)
    public int? CustomerId { get; set; } // Null if Payable
    public int? SupplierId { get; set; } // Null if Receivable
    public string ReferenceNumber { get; set; } = string.Empty; // Invoice/PO number
    public int ReferenceId { get; set; } // Sale ID or PurchaseOrder ID
    public DateTime TransactionDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal OutstandingAmount { get; set; }
    public int DaysOverdue { get; set; } // Calculated field
    public string Status { get; set; } = "Pending"; // Pending, PartiallyPaid, Paid, Overdue, Disputed
    public string? Notes { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    
    /// <summary>
    /// Calculates days overdue
    /// </summary>
    public void CalculateDaysOverdue()
    {
        if (OutstandingAmount > 0 && DateTime.Now > DueDate)
        {
            DaysOverdue = (int)(DateTime.Now - DueDate).TotalDays;
        }
    }
}
