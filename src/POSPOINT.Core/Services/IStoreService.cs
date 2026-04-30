using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IStoreService
{
    Task<IEnumerable<Store>> GetAllStoresAsync();
    Task<Store?> GetStoreByIdAsync(int storeId);
    Task<int> AddStoreAsync(Store store);
    Task<bool> UpdateStoreAsync(Store store);
    Task<bool> DeleteStoreAsync(int storeId);
}
