using POSPOINT.Data;
using POSPOINT.Models.DTOs;
using POSPOINT.Models.Entities;

namespace POSPOINT.Core.Services.Implementations;

public class PricingSlabService : IPricingSlabService
{
    private readonly DatabaseConnection _dbConnection;

    public PricingSlabService(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<PricingSlab>> GetSlabsByVariantIdAsync(int variantId)
    {
        var slabs = new List<PricingSlab>();
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT * FROM PricingSlabs 
                        WHERE VariantId = @VariantId AND IsActive = 1
                        ORDER BY SlabSize ASC";
                    cmd.Parameters.AddWithValue("@VariantId", variantId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            slabs.Add(MapToPricingSlab(reader));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching pricing slabs for variant {variantId}", ex);
        }

        return slabs;
    }

    public async Task<PricingSlab?> GetActiveSlabAsync(int variantId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT TOP 1 * FROM PricingSlabs 
                        WHERE VariantId = @VariantId 
                        AND IsActive = 1
                        AND GETDATE() BETWEEN StartDate AND EndDate";
                    cmd.Parameters.AddWithValue("@VariantId", variantId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToPricingSlab(reader);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching active slab for variant {variantId}", ex);
        }

        return null;
    }

    /// <summary>
    /// Calculate price with slab-based discount
    /// Example: Normal=₹10, Discount=₹9, SlabSize=10
    /// Qty=25 → (20 × ₹9) + (5 × ₹10) = ₹230
    /// </summary>
    public async Task<PricingSlabCalculationDTO> CalculatePriceWithSlabAsync(int variantId, int quantity)
    {
        var slab = await GetActiveSlabAsync(variantId);
        
        if (slab == null)
        {
            throw new Exception($"No active pricing slab found for variant {variantId}");
        }

        var calculation = new PricingSlabCalculationDTO
        {
            VariantId = variantId,
            Quantity = quantity,
            NormalPrice = slab.NormalPrice,
            DiscountPrice = slab.DiscountPrice,
            SlabSize = slab.SlabSize
        };

        // Calculate discounted units (multiples of slab size)
        calculation.DiscountedUnits = (quantity / slab.SlabSize) * slab.SlabSize;
        calculation.RegularUnits = quantity - calculation.DiscountedUnits;

        // Calculate amounts
        calculation.DiscountedAmount = calculation.DiscountedUnits * slab.DiscountPrice;
        calculation.RegularAmount = calculation.RegularUnits * slab.NormalPrice;
        calculation.TotalAmount = calculation.DiscountedAmount + calculation.RegularAmount;
        calculation.TotalDiscount = (quantity * slab.NormalPrice) - calculation.TotalAmount;
        calculation.AveragePrice = calculation.TotalAmount / quantity;

        return calculation;
    }

    public async Task<int> AddPricingSlabAsync(PricingSlab slab)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO PricingSlabs (VariantId, SlabSize, NormalPrice, DiscountPrice, DiscountPercentage, StartDate, EndDate, IsActive, CreatedDate)
                        VALUES (@VariantId, @SlabSize, @NormalPrice, @DiscountPrice, @DiscountPercentage, @StartDate, @EndDate, 1, GETDATE());
                        SELECT SCOPE_IDENTITY();";
                    
                    cmd.Parameters.AddWithValue("@VariantId", slab.VariantId);
                    cmd.Parameters.AddWithValue("@SlabSize", slab.SlabSize);
                    cmd.Parameters.AddWithValue("@NormalPrice", slab.NormalPrice);
                    cmd.Parameters.AddWithValue("@DiscountPrice", slab.DiscountPrice);
                    cmd.Parameters.AddWithValue("@DiscountPercentage", slab.DiscountPercentage);
                    cmd.Parameters.AddWithValue("@StartDate", slab.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", slab.EndDate);

                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding pricing slab", ex);
        }
    }

    public async Task<bool> UpdatePricingSlabAsync(PricingSlab slab)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE PricingSlabs SET
                            NormalPrice = @NormalPrice,
                            DiscountPrice = @DiscountPrice,
                            DiscountPercentage = @DiscountPercentage,
                            StartDate = @StartDate,
                            EndDate = @EndDate,
                            UpdatedDate = GETDATE()
                        WHERE PricingSlabId = @PricingSlabId";
                    
                    cmd.Parameters.AddWithValue("@PricingSlabId", slab.PricingSlabId);
                    cmd.Parameters.AddWithValue("@NormalPrice", slab.NormalPrice);
                    cmd.Parameters.AddWithValue("@DiscountPrice", slab.DiscountPrice);
                    cmd.Parameters.AddWithValue("@DiscountPercentage", slab.DiscountPercentage);
                    cmd.Parameters.AddWithValue("@StartDate", slab.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", slab.EndDate);

                    var rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating pricing slab", ex);
        }
    }

    public async Task<bool> DeletePricingSlabAsync(int slabId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE PricingSlabs SET IsActive = 0 WHERE PricingSlabId = @PricingSlabId";
                    cmd.Parameters.AddWithValue("@PricingSlabId", slabId);

                    var rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting pricing slab", ex);
        }
    }

    private PricingSlab MapToPricingSlab(System.Data.IDataReader reader)
    {
        return new PricingSlab
        {
            PricingSlabId = (int)reader["PricingSlabId"],
            VariantId = (int)reader["VariantId"],
            SlabSize = (int)reader["SlabSize"],
            NormalPrice = (decimal)reader["NormalPrice"],
            DiscountPrice = (decimal)reader["DiscountPrice"],
            DiscountPercentage = (decimal)reader["DiscountPercentage"],
            StartDate = (DateTime)reader["StartDate"],
            EndDate = (DateTime)reader["EndDate"],
            IsActive = (bool)reader["IsActive"],
            CreatedDate = (DateTime)reader["CreatedDate"],
            UpdatedDate = reader["UpdatedDate"] == DBNull.Value ? null : (DateTime)reader["UpdatedDate"]
        };
    }
}
