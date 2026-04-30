# Slab-Based Pricing System

## Overview

The slab-based pricing system applies discounts only on complete slab quantities, charging the remaining units at normal price.

## Pricing Logic

### Example Configuration
```
Product: Rice (10kg Bag)
Variant: "10kg Bag"
Normal Price: ₹10 per unit
Discount Price: ₹9 per unit
Slab Size: 10 units
```

### Calculation Examples

#### Example 1: Exact Slab Match
```
Quantity: 10 units
Discounted Units: 10 (1 complete slab)
Regular Units: 0 (no remainder)

Calculation:
10 × ₹9 = ₹90

Total: ₹90
Discount: ₹10 (1 unit × ₹10)
```

#### Example 2: Multiple Complete Slabs
```
Quantity: 20 units
Discounted Units: 20 (2 complete slabs)
Regular Units: 0

Calculation:
20 × ₹9 = ₹180

Total: ₹180
Discount: ₹20 (2 units × ₹10)
```

#### Example 3: Mixed (Complete + Remainder)
```
Quantity: 25 units
Slab Size: 10

Discounted Units: 20 (2 complete slabs)
Regular Units: 5 (remainder)

Calculation:
20 × ₹9 = ₹180 (discount price for complete slabs)
5 × ₹10 = ₹50 (normal price for remainder)

Total: ₹230
Discount: ₹20 (applied only to 2 complete slabs)
Average Price: ₹230 ÷ 25 = ₹9.20 per unit
```

#### Example 4: Partial Slab
```
Quantity: 15 units
Slab Size: 10

Discounted Units: 10 (1 complete slab)
Regular Units: 5 (remainder - doesn't form complete slab)

Calculation:
10 × ₹9 = ₹90 (discount on 1 complete slab)
5 × ₹10 = ₹50 (normal price for 5 units)

Total: ₹140
Discount: ₹10 (only on 1 complete slab)
Average Price: ₹140 ÷ 15 = ₹9.33 per unit
```

## Key Rules

1. **Only Full Slabs Get Discount**
   - Discount applies ONLY to complete slab quantities
   - Partial slabs are charged at normal price

2. **No Mixed Pricing Within Slab**
   - If 10 units = 1 slab, you can't charge 8 at discount + 2 at normal
   - Either 10 units get discount or they don't

3. **Remainder Always at Normal Price**
   - Any units that don't form a complete slab
   - Always charged at normal price

4. **Calculation Priority**
   ```
   Total Units = (Complete Slabs × Slab Size) + Remainder
   Discounted Amount = Complete Slabs × Slab Size × Discount Price
   Regular Amount = Remainder × Normal Price
   Total = Discounted Amount + Regular Amount
   ```

## Database Schema

```sql
CREATE TABLE PricingSlabs (
    PricingSlabId INT PRIMARY KEY,
    VariantId INT NOT NULL,
    SlabSize INT, -- e.g., 10
    NormalPrice DECIMAL(10, 2), -- ₹10
    DiscountPrice DECIMAL(10, 2), -- ₹9
    DiscountPercentage DECIMAL(5, 2), -- 10%
    StartDate DATETIME,
    EndDate DATETIME,
    IsActive BIT,
    FOREIGN KEY (VariantId) REFERENCES Variants(VariantId)
);
```

## Service Implementation

```csharp
public async Task<PricingSlabCalculationDTO> CalculatePriceWithSlabAsync(
    int variantId, 
    int quantity)
{
    // Step 1: Get active pricing slab
    var slab = await GetActiveSlabAsync(variantId);
    
    // Step 2: Calculate complete slabs and remainder
    var discountedUnits = (quantity / slab.SlabSize) * slab.SlabSize;
    var regularUnits = quantity - discountedUnits;
    
    // Step 3: Calculate amounts
    var discountedAmount = discountedUnits * slab.DiscountPrice;
    var regularAmount = regularUnits * slab.NormalPrice;
    var totalAmount = discountedAmount + regularAmount;
    
    return new PricingSlabCalculationDTO
    {
        DiscountedUnits = discountedUnits,
        RegularUnits = regularUnits,
        DiscountedAmount = discountedAmount,
        RegularAmount = regularAmount,
        TotalAmount = totalAmount,
        AveragePrice = totalAmount / quantity
    };
}
```

## Usage in POS

### Setup Pricing Slab
```csharp
var slab = new PricingSlab
{
    VariantId = 1,
    SlabSize = 10,
    NormalPrice = 10m,
    DiscountPrice = 9m,
    DiscountPercentage = 10m,
    StartDate = DateTime.Now,
    EndDate = DateTime.Now.AddMonths(1),
    IsActive = true
};

await pricingService.AddPricingSlabAsync(slab);
```

### Calculate Price During Billing
```csharp
// Customer buys 25 units
var calculation = await pricingService.CalculatePriceWithSlabAsync(variantId, 25);

// Result:
// DiscountedUnits: 20 → 20 × ₹9 = ₹180
// RegularUnits: 5 → 5 × ₹10 = ₹50
// Total: ₹230

var saleItem = new SaleItem
{
    VariantId = variantId,
    Quantity = 25,
    UnitPrice = calculation.AveragePrice, // ₹9.20
    LineAmount = calculation.TotalAmount, // ₹230
    DiscountAmount = calculation.TotalDiscount // ₹20
};
```

## Business Scenarios

### Scenario 1: Wholesale Pricing
```
Product: Notebook (Box of 10)
Wholesale Deal:
- Buy 1 box (10) → ₹90 (full discount)
- Buy 2 boxes (20) → ₹180 (full discount)
- Buy 2.5 boxes (25) → ₹230 (20 at discount + 5 at normal)
```

### Scenario 2: Tiered Slabs
```
Product: t-Shirt
Slab 1: 1-9 units → ₹500 each
Slab 2: 10-19 units → ₹450 each (10% off)
Slab 3: 20+ units → ₹400 each (20% off)

// Buy 25 units
20 × ₹400 = ₹8,000 (2 complete slabs of Slab 3)
5 × ₹450 = ₹2,250 (remainder at Slab 2 price)
Total = ₹10,250
```

## Reports & Analytics

### Sales Report with Slab Pricing
```
Sale ID: 1001
Date: 2026-05-15
Item: Rice (10kg)
Quantity: 25 units
Normal Price: ₹10/unit
Slab Configuration: 10 units @ ₹9

Detailed Breakdown:
- 20 units @ ₹9 = ₹180 (2 complete slabs)
- 5 units @ ₹10 = ₹50 (remainder)
Total: ₹230
Total Discount: ₹20
```

## Performance Tips

1. **Index on VariantId & DateRange**
   ```sql
   CREATE INDEX IX_PricingSlabs_DateRange 
   ON PricingSlabs(StartDate, EndDate);
   ```

2. **Cache Active Slabs**
   - Cache slab definitions per variant
   - Refresh daily or when slab changes

3. **Batch Calculations**
   - Calculate for multiple items in single query
   - Reduce database hits

## Common Mistakes to Avoid

❌ **Wrong**: Apply 10% discount to all 25 units
- 25 × ₹10 × 0.9 = ₹225 (WRONG)

✅ **Correct**: Apply discount only to complete slabs
- (20 × ₹9) + (5 × ₹10) = ₹230 (CORRECT)

❌ **Wrong**: Create new slab for partial quantities
- Don't treat 5 as a new "5-unit slab"

✅ **Correct**: Remainder always uses normal price
- Remainder is charged at full normal price

## Testing Examples

```csharp
[TestClass]
public class PricingSlabTests
{
    [TestMethod]
    public async Task ExactSlabMatch_ShouldApplyDiscountToAll()
    {
        // Qty 10, SlabSize 10 → All get discount
        var result = await service.CalculatePriceWithSlabAsync(1, 10);
        Assert.AreEqual(90m, result.TotalAmount); // 10 × ₹9
    }

    [TestMethod]
    public async Task PartialSlab_ShouldMixPrices()
    {
        // Qty 25, SlabSize 10 → 20 discount + 5 normal
        var result = await service.CalculatePriceWithSlabAsync(1, 25);
        Assert.AreEqual(180m, result.DiscountedAmount); // 20 × ₹9
        Assert.AreEqual(50m, result.RegularAmount); // 5 × ₹10
        Assert.AreEqual(230m, result.TotalAmount);
    }
}
```
