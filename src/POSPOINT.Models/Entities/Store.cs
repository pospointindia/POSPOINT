namespace POSPOINT.Models.Entities;

public class Store
{
    public int StoreId { get; set; }
    public string StoreName { get; set; } = string.Empty;
    public string StoreType { get; set; } = string.Empty; // Supermarket, Chemist, Garments, Restaurant
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}
