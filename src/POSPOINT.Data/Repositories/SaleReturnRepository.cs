using POSPOINT.Models.Entities;

namespace POSPOINT.Data.Repositories;

/// <summary>
/// Repository for managing SaleReturn entities
/// </summary>
public class SaleReturnRepository : BaseRepository<SaleReturn>
{
    public SaleReturnRepository(DatabaseConnection dbConnection) : base(dbConnection)
    {
    }

    public override async Task<IEnumerable<SaleReturn>> GetAllAsync()
    {
        const string query = "SELECT * FROM SaleReturns ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<SaleReturn>(query);
    }

    public override async Task<SaleReturn?> GetByIdAsync(int id)
    {
        const string query = "SELECT * FROM SaleReturns WHERE SaleReturnId = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<SaleReturn>(query, new { Id = id });
    }

    public async Task<IEnumerable<SaleReturn>> GetByStoreAsync(int storeId)
    {
        const string query = "SELECT * FROM SaleReturns WHERE StoreId = @StoreId ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<SaleReturn>(query, new { StoreId = storeId });
    }

    public async Task<IEnumerable<SaleReturn>> GetByCustomerAsync(int customerId)
    {
        const string query = "SELECT * FROM SaleReturns WHERE CustomerId = @CustomerId ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<SaleReturn>(query, new { CustomerId = customerId });
    }

    public async Task<IEnumerable<SaleReturn>> GetBySaleAsync(int saleId)
    {
        const string query = "SELECT * FROM SaleReturns WHERE SaleId = @SaleId ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<SaleReturn>(query, new { SaleId = saleId });
    }

    public override async Task<int> AddAsync(SaleReturn entity)
    {
        const string query = @"INSERT INTO SaleReturns (SRNumber, SaleId, StoreId, CustomerId, ReturnDate, ReturnReason, 
                            TotalQuantity, TotalAmount, DiscountAmount, TaxAmount, NetAmount, RefundMethod, Status, Notes, 
                            ProcessedByUserId, CreatedDate)
                            VALUES (@SRNumber, @SaleId, @StoreId, @CustomerId, @ReturnDate, @ReturnReason, @TotalQuantity, 
                            @TotalAmount, @DiscountAmount, @TaxAmount, @NetAmount, @RefundMethod, @Status, @Notes, 
                            @ProcessedByUserId, @CreatedDate);
                            SELECT CAST(SCOPE_IDENTITY() as int)";
        
        return await _dbConnection.ExecuteScalarAsync<int>(query, entity);
    }

    public override async Task<bool> UpdateAsync(SaleReturn entity)
    {
        const string query = @"UPDATE SaleReturns SET SRNumber = @SRNumber, ReturnDate = @ReturnDate, ReturnReason = @ReturnReason, 
                            TotalQuantity = @TotalQuantity, TotalAmount = @TotalAmount, DiscountAmount = @DiscountAmount, 
                            TaxAmount = @TaxAmount, NetAmount = @NetAmount, RefundMethod = @RefundMethod, Status = @Status, 
                            Notes = @Notes, ProcessedByUserId = @ProcessedByUserId, ProcessedDate = @ProcessedDate, 
                            ApprovedByUserId = @ApprovedByUserId, ApprovedDate = @ApprovedDate, RefundAmount = @RefundAmount, 
                            RefundDate = @RefundDate WHERE SaleReturnId = @SaleReturnId";
        
        var result = await _dbConnection.ExecuteAsync(query, entity);
        return result > 0;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        const string query = "DELETE FROM SaleReturns WHERE SaleReturnId = @Id";
        var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }
}
