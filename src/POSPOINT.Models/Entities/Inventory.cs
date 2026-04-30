namespace POSPOINT.Models.Entities;

public class Inventory
{
    public int InventoryId { get; set; }
    public int StoreId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int ReorderLevel { get; set; }
    public DateTime LastRestockDate { get; set; }
    public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
}
