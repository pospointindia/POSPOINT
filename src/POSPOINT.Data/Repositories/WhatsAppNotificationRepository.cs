using POSPOINT.Models.Entities;
using POSPOINT.Data.Repositories;

namespace POSPOINT.Data.Repositories;

/// <summary>
/// Repository for managing WhatsAppNotification entities
/// </summary>
public class WhatsAppNotificationRepository : BaseRepository<WhatsAppNotification>
{
    public WhatsAppNotificationRepository(DatabaseConnection dbConnection) : base(dbConnection)
    {
    }

    public override async Task<IEnumerable<WhatsAppNotification>> GetAllAsync()
    {
        const string query = "SELECT * FROM WhatsAppNotifications ORDER BY SentDate DESC";
        return await _dbConnection.QueryAsync<WhatsAppNotification>(query);
    }

    public override async Task<WhatsAppNotification?> GetByIdAsync(int id)
    {
        const string query = "SELECT * FROM WhatsAppNotifications WHERE WhatsAppNotificationId = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<WhatsAppNotification>(query, new { Id = id });
    }

    public async Task<WhatsAppNotification?> GetByMessageIdAsync(string messageId)
    {
        const string query = "SELECT * FROM WhatsAppNotifications WHERE MessageId = @MessageId";
        return await _dbConnection.QueryFirstOrDefaultAsync<WhatsAppNotification>(query, new { MessageId = messageId });
    }

    public async Task<IEnumerable<WhatsAppNotification>> GetByStoreAsync(int storeId)
    {
        const string query = "SELECT * FROM WhatsAppNotifications WHERE StoreId = @StoreId ORDER BY SentDate DESC";
        return await _dbConnection.QueryAsync<WhatsAppNotification>(query, new { StoreId = storeId });
    }

    public async Task<IEnumerable<WhatsAppNotification>> GetByStatusAsync(int storeId, string status)
    {
        const string query = "SELECT * FROM WhatsAppNotifications WHERE StoreId = @StoreId AND Status = @Status ORDER BY SentDate DESC";
        return await _dbConnection.QueryAsync<WhatsAppNotification>(query, new { StoreId = storeId, Status = status });
    }

    public async Task<IEnumerable<WhatsAppNotification>> GetFailedMessagesAsync(int storeId)
    {
        const string query = "SELECT * FROM WhatsAppNotifications WHERE StoreId = @StoreId AND Status = 'Failed' ORDER BY SentDate DESC";
        return await _dbConnection.QueryAsync<WhatsAppNotification>(query, new { StoreId = storeId });
    }

    public override async Task<int> AddAsync(WhatsAppNotification entity)
    {
        const string query = @"INSERT INTO WhatsAppNotifications (MessageId, RecipientPhoneNumber, RecipientName, StoreId, 
                            NotificationType, TemplateId, MessageContent, Status, RelatedSaleId, RelatedPurchaseOrderId, 
                            RelatedSaleReturnId, RelatedPurchaseReturnId, SentDate, AttemptCount, MediaUrl, CreatedByUserId)
                            VALUES (@MessageId, @RecipientPhoneNumber, @RecipientName, @StoreId, @NotificationType, 
                            @TemplateId, @MessageContent, @Status, @RelatedSaleId, @RelatedPurchaseOrderId, 
                            @RelatedSaleReturnId, @RelatedPurchaseReturnId, @SentDate, @AttemptCount, @MediaUrl, @CreatedByUserId);
                            SELECT CAST(SCOPE_IDENTITY() as int)";
        
        return await _dbConnection.ExecuteScalarAsync<int>(query, entity);
    }

    public override async Task<bool> UpdateAsync(WhatsAppNotification entity)
    {
        const string query = @"UPDATE WhatsAppNotifications SET Status = @Status, FailureReason = @FailureReason, 
                            DeliveredDate = @DeliveredDate, ReadDate = @ReadDate, AttemptCount = @AttemptCount, 
                            LastAttemptDate = @LastAttemptDate WHERE WhatsAppNotificationId = @WhatsAppNotificationId";
        
        var result = await _dbConnection.ExecuteAsync(query, entity);
        return result > 0;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        const string query = "DELETE FROM WhatsAppNotifications WHERE WhatsAppNotificationId = @Id";
        var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }
}
