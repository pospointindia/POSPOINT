namespace POSPOINT.Models.Entities;

public class Barcode
{
    public int BarcodeId { get; set; }
    public int ProductId { get; set; }
    public string BarcodeValue { get; set; } = string.Empty;
    public string BarcodeType { get; set; } = string.Empty; // EAN13, Code128, QR, etc.
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
