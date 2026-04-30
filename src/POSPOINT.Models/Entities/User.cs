namespace POSPOINT.Models.Entities;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? StoreId { get; set; }
    public string Role { get; set; } = string.Empty; // Admin, Manager, Cashier, Staff
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? LastLoginDate { get; set; }
}
