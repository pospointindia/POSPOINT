using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IImportExportService
{
    // Purchase Import
    Task<int> ImportPurchaseOrderAsync(Stream csvStream);
    Task<bool> ExportPurchaseOrdersAsync(int storeId, DateTime startDate, DateTime endDate, string filePath);
    
    // Sales Import/Export
    Task<bool> ExportSalesAsync(int storeId, DateTime startDate, DateTime endDate, string filePath);
    Task<int> ImportSalesAsync(Stream csvStream);
    
    // Inventory Import
    Task<int> ImportInventoryAsync(Stream csvStream);
    Task<bool> ExportInventoryAsync(int storeId, string filePath);
    
    // Products Import
    Task<int> ImportProductsAsync(Stream csvStream);
}
