using POSPOINT.Models.DTOs;

namespace POSPOINT.Core.Services;

public interface IPDFGenerationService
{
    Task<byte[]> GenerateBillPDFAsync(BillToPrintDTO bill);
    Task<byte[]> GenerateSalesReportPDFAsync(IEnumerable<SalesReportDTO> sales);
    Task<byte[]> GenerateGSTReportPDFAsync(GSTReportDTO gstReport);
    Task<byte[]> GeneratePurchaseOrderPDFAsync(int purchaseOrderId);
}
