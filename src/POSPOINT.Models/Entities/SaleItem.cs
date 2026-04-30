namespace POSPOINT.Models.Entities;

public class SaleItem
{
    public int SaleItemId { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineAmount { get; set; }
}
