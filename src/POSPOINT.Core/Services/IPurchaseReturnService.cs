using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

/// <summary>
/// Service interface for managing purchase returns/debit notes
/// </summary>
public interface IPurchaseReturnService
{
    // CRUD Operations
    Task<PurchaseReturn?> GetByIdAsync(int purchaseReturnId);
    Task<IEnumerable<PurchaseReturn>> GetByStoreAsync(int storeId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<PurchaseReturn>> GetBySupplierAsync(int supplierId);
    Task<IEnumerable<PurchaseReturn>> GetByPurchaseOrderAsync(int purchaseOrderId);
    Task<int> CreateAsync(PurchaseReturn purchaseReturn, List<PurchaseReturnItem> items);
    Task<bool> UpdateAsync(PurchaseReturn purchaseReturn);
    Task<bool> DeleteAsync(int purchaseReturnId);
    
    // Status Management
    Task<bool> ApproveAsync(int purchaseReturnId, int userId);
    Task<bool> RejectAsync(int purchaseReturnId, string reason);
    Task<bool> MarkAsReceivedBySupplierAsync(int purchaseReturnId);
    
    // Reporting
    Task<decimal> GetTotalReturnAmountAsync(int storeId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<PurchaseReturn>> GetPendingReturnsAsync(int storeId);
    Task<decimal> GetReturnAmountBySupplierAsync(int supplierId, DateTime startDate, DateTime endDate);
}
