using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IBarcodeGenerationService
{
    Task<byte[]> GenerateBarcodeImageAsync(string barcodeValue, string format = "png", int? width = null, int? height = null);
    Task<byte[]> GenerateMultipleBarcodesAsync(List<string> barcodeValues, int barcodesPerRow, int templateWidth, int templateHeight);
    Task<BarcodeTemplate?> GetTemplateAsync(int templateId);
    Task<IEnumerable<BarcodeTemplate>> GetAllTemplatesAsync();
    Task<int> AddTemplateAsync(BarcodeTemplate template);
}
