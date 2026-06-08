using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

/// <summary>
/// Service interface for managing sale returns/credit notes
/// </summary>
public interface ISaleReturnService
{
    // CRUD Operations
    Task<SaleReturn?> GetByIdAsync(int saleReturnId);
    Task<IEnumerable<SaleReturn>> GetByStoreAsync(int storeId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<SaleReturn>> GetByCustomerAsync(int customerId);
    Task<IEnumerable<SaleReturn>> GetBySaleAsync(int saleId);
    Task<int> CreateAsync(SaleReturn saleReturn, List<SaleReturnItem> items);
    Task<bool> UpdateAsync(SaleReturn saleReturn);
    Task<bool> DeleteAsync(int saleReturnId);
    
    // Status Management
    Task<bool> ApproveAsync(int saleReturnId, int userId);
    Task<bool> RejectAsync(int saleReturnId, string reason);
    Task<bool> ProcessRefundAsync(int saleReturnId, int userId);
    
    // Refund Management
    Task<bool> InitiateRefundAsync(int saleReturnId, decimal refundAmount, string method);
    Task<bool> CompleteRefundAsync(int saleReturnId);
    Task<IEnumerable<SaleReturn>> GetPendingRefundsAsync(int storeId);
    
    // Reporting
    Task<decimal> GetTotalReturnAmountAsync(int storeId, DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalRefundedAsync(int storeId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<SaleReturn>> GetPendingApprovalsAsync(int storeId);
    Task<decimal> GetReturnPercentageAsync(int storeId, DateTime startDate, DateTime endDate);
}
