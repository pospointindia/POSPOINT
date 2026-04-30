namespace POSPOINT.Models.DTOs;

public class SalesReportDTO
{
    public int SaleId { get; set; }
    public DateTime SaleDate { get; set; }
    public string? SalesManName { get; set; }
    public string? PartyName { get; set; }
    public string? StoreName { get; set; }
    public List<SalesReportItemDTO> Items { get; set; } = new();
    public decimal SubTotal { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
}

public class SalesReportItemDTO
{
    public string ProductName { get; set; } = string.Empty;
    public string? VariantName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
}
