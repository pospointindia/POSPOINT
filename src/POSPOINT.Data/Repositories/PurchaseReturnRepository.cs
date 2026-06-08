using POSPOINT.Models.Entities;

namespace POSPOINT.Data.Repositories;

/// <summary>
/// Repository for managing PurchaseReturn entities
/// </summary>
public class PurchaseReturnRepository : BaseRepository<PurchaseReturn>
{
    public PurchaseReturnRepository(DatabaseConnection dbConnection) : base(dbConnection)
    {
    }

    public override async Task<IEnumerable<PurchaseReturn>> GetAllAsync()
    {
        const string query = "SELECT * FROM PurchaseReturns ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<PurchaseReturn>(query);
    }

    public override async Task<PurchaseReturn?> GetByIdAsync(int id)
    {
        const string query = "SELECT * FROM PurchaseReturns WHERE PurchaseReturnId = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<PurchaseReturn>(query, new { Id = id });
    }

    public async Task<IEnumerable<PurchaseReturn>> GetByStoreAsync(int storeId)
    {
        const string query = "SELECT * FROM PurchaseReturns WHERE StoreId = @StoreId ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<PurchaseReturn>(query, new { StoreId = storeId });
    }

    public async Task<IEnumerable<PurchaseReturn>> GetBySupplierAsync(int supplierId)
    {
        const string query = "SELECT * FROM PurchaseReturns WHERE SupplierId = @SupplierId ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<PurchaseReturn>(query, new { SupplierId = supplierId });
    }

    public override async Task<int> AddAsync(PurchaseReturn entity)
    {
        const string query = @"INSERT INTO PurchaseReturns (PRNumber, PurchaseOrderId, SupplierId, StoreId, ReturnDate, 
                            ReturnReason, TotalQuantity, TotalAmount, TaxAmount, NetAmount, Status, Notes, CreatedByUserId, CreatedDate)
                            VALUES (@PRNumber, @PurchaseOrderId, @SupplierId, @StoreId, @ReturnDate, @ReturnReason, 
                            @TotalQuantity, @TotalAmount, @TaxAmount, @NetAmount, @Status, @Notes, @CreatedByUserId, @CreatedDate);
                            SELECT CAST(SCOPE_IDENTITY() as int)";
        
        return await _dbConnection.ExecuteScalarAsync<int>(query, entity);
    }

    public override async Task<bool> UpdateAsync(PurchaseReturn entity)
    {
        const string query = @"UPDATE PurchaseReturns SET PRNumber = @PRNumber, ReturnDate = @ReturnDate, 
                            ReturnReason = @ReturnReason, TotalQuantity = @TotalQuantity, TotalAmount = @TotalAmount, 
                            TaxAmount = @TaxAmount, NetAmount = @NetAmount, Status = @Status, Notes = @Notes, 
                            ApprovedByUserId = @ApprovedByUserId, ApprovedDate = @ApprovedDate, DocumentPath = @DocumentPath
                            WHERE PurchaseReturnId = @PurchaseReturnId";
        
        var result = await _dbConnection.ExecuteAsync(query, entity);
        return result > 0;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        const string query = "DELETE FROM PurchaseReturns WHERE PurchaseReturnId = @Id";
        var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }
}
