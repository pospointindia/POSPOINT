using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IBarcodeService
{
    Task<IEnumerable<Barcode>> GetBarcodesByProductIdAsync(int productId);
    Task<Barcode?> GetBarcodeByValueAsync(string barcodeValue);
    Task<int> AddBarcodeAsync(Barcode barcode);
    Task<bool> UpdateBarcodeAsync(Barcode barcode);
    Task<bool> DeleteBarcodeAsync(int barcodeId);
}
