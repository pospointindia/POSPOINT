namespace POSPOINT.Models.Entities;

public class SalesMan
{
    public int SalesManId { get; set; }
    public string SalesManName { get; set; } = string.Empty;
    public string SalesManCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int? StoreId { get; set; }
    public decimal CommissionPercentage { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
