namespace POSPOINT.Models.DTOs;

public class PricingSlabCalculationDTO
{
    public int VariantId { get; set; }
    public int Quantity { get; set; }
    public decimal NormalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public int SlabSize { get; set; }
    
    // Calculated values
    public int DiscountedUnits { get; set; } // Units at discount price
    public int RegularUnits { get; set; } // Units at normal price
    public decimal DiscountedAmount { get; set; }
    public decimal RegularAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal AveragePrice { get; set; }
}
