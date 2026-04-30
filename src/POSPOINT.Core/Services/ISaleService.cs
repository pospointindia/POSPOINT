using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface ISaleService
{
    Task<int> CreateSaleAsync(Sale sale, List<SaleItem> items);
    Task<Sale?> GetSaleByIdAsync(int saleId);
    Task<IEnumerable<Sale>> GetSalesByStoreAsync(int storeId, DateTime from, DateTime to);
    Task<IEnumerable<SaleItem>> GetSaleItemsAsync(int saleId);
}
