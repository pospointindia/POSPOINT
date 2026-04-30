using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IInventoryService
{
    Task<Inventory?> GetInventoryAsync(int storeId, int productId);
    Task<IEnumerable<Inventory>> GetStoreInventoryAsync(int storeId);
    Task<int> AddInventoryAsync(Inventory inventory);
    Task<bool> UpdateInventoryAsync(Inventory inventory);
    Task<bool> UpdateStockAsync(int storeId, int productId, int quantity);
}
