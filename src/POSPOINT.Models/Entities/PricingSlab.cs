namespace POSPOINT.Models.Entities;

public class PricingSlab
{
    public int PricingSlabId { get; set; }
    public int VariantId { get; set; }
    public int SlabSize { get; set; } // e.g., 10 units
    public decimal NormalPrice { get; set; } // ₹10
    public decimal DiscountPrice { get; set; } // ₹9
    public decimal DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}
