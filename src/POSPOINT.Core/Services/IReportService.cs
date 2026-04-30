using POSPOINT.Models.DTOs;

namespace POSPOINT.Core.Services;

public interface IReportService
{
    // Sales Reports
    Task<IEnumerable<SalesReportDTO>> GetSalesReportAsync(int storeId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<SalesReportDTO>> GetSalesReportBySalesManAsync(int salesManId, DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalSalesByStoreAsync(int storeId, DateTime startDate, DateTime endDate);
    
    // GST Reports
    Task<GSTReportDTO> GenerateGSTReportAsync(int storeId, string period);
    
    // Purchase Reports
    Task<IEnumerable<PurchaseReportDTO>> GetPurchaseReportAsync(int storeId, DateTime startDate, DateTime endDate);
}

public class GSTReportDTO
{
    public string GSTPeriod { get; set; } = string.Empty;
    public decimal TotalSales { get; set; }
    public decimal TotalPurchase { get; set; }
    public decimal OutputGST { get; set; }
    public decimal InputGST { get; set; }
    public decimal GSTPayable { get; set; }
}

public class PurchaseReportDTO
{
    public int PurchaseOrderId { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public string? SupplierName { get; set; }
    public DateTime PODate { get; set; }
    public decimal TotalAmount { get; set; }
}
