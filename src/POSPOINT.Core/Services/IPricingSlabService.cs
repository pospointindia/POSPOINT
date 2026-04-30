using POSPOINT.Models.DTOs;
using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services;

public interface IPricingSlabService
{
    Task<IEnumerable<PricingSlab>> GetSlabsByVariantIdAsync(int variantId);
    Task<PricingSlab?> GetActiveSlabAsync(int variantId);
    Task<PricingSlabCalculationDTO> CalculatePriceWithSlabAsync(int variantId, int quantity);
    Task<int> AddPricingSlabAsync(PricingSlab slab);
    Task<bool> UpdatePricingSlabAsync(PricingSlab slab);
    Task<bool> DeletePricingSlabAsync(int slabId);
}
