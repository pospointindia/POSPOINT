using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int productId);
    Task<Product?> GetProductByCodeAsync(string productCode);
    Task<int> AddProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int productId);
}
