namespace POSPOINT.Models.Entities;

public class GSTReport
{
    public int GSTReportId { get; set; }
    public int StoreId { get; set; }
    public string GSTPeriod { get; set; } = string.Empty; // e.g., "April-2026"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalSales { get; set; }
    public decimal TotalPurchase { get; set; }
    public decimal OutputGST { get; set; } // GST on Sales
    public decimal InputGST { get; set; } // GST on Purchases
    public decimal GSTPayable { get; set; } // OutputGST - InputGST
    public string Status { get; set; } = "Draft"; // Draft, Submitted, Approved
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
