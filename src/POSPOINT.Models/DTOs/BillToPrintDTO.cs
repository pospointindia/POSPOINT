namespace POSPOINT.Models.DTOs;

public class BillToPrintDTO
{
    public int SaleId { get; set; }
    public DateTime SaleDate { get; set; }
    public string BillNumber { get; set; } = string.Empty;
    
    // Bill From
    public string StoreName { get; set; } = string.Empty;
    public string StoreAddress { get; set; } = string.Empty;
    public string StoreCity { get; set; } = string.Empty;
    public string StorePhoneNumber { get; set; } = string.Empty;
    
    // Bill To
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerPhone { get; set; }
    public string? GSTINNumber { get; set; }
    
    // Ship To
    public string? ShipToName { get; set; }
    public string? ShipToAddress { get; set; }
    public string? ShipToCity { get; set; }
    
    // Transporter Info
    public string? TransporterName { get; set; }
    public string? TransporterPhone { get; set; }
    public string? LorryNumber { get; set; }
    
    // Sales Man Info
    public string? SalesManName { get; set; }
    public string? SalesManPhone { get; set; }
    
    public List<BillItemDTO> Items { get; set; } = new();
    public decimal SubTotal { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
}

public class BillItemDTO
{
    public string ItemName { get; set; } = string.Empty;
    public string? VariantName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
}
