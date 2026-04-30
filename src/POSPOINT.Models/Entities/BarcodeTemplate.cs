namespace POSPOINT.Models.Entities;

public class BarcodeTemplate
{
    public int BarcodeTemplateId { get; set; }
    public string TemplateName { get; set; } = string.Empty;
    public int Width { get; set; } // e.g., 38
    public int Height { get; set; } // e.g., 25
    public string Unit { get; set; } = "mm"; // mm, inch
    public int BarcodesPerRow { get; set; } // e.g., 2 for 60x40
    public int BarcodesPerColumn { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
