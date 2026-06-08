namespace POSPOINT.Models.Entities;

/// <summary>
/// Tracks WhatsApp notifications sent to customers/suppliers
/// </summary>
public class WhatsAppNotification
{
    public int WhatsAppNotificationId { get; set; }
    public string MessageId { get; set; } = string.Empty; // Unique ID from WhatsApp
    public string RecipientPhoneNumber { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;
    public int StoreId { get; set; }
    public string NotificationType { get; set; } = string.Empty; // "OrderConfirmation", "SaleInvoice", "SaleReturn", "PurchaseOrder", "PaymentReminder", etc.
    public string TemplateId { get; set; } = string.Empty; // WhatsApp template ID
    public string MessageContent { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending, Sent, Delivered, Read, Failed
    public string? FailureReason { get; set; }
    public int? RelatedSaleId { get; set; } // Reference to Sale if applicable
    public int? RelatedPurchaseOrderId { get; set; } // Reference to PO if applicable
    public int? RelatedSaleReturnId { get; set; }
    public int? RelatedPurchaseReturnId { get; set; }
    public DateTime SentDate { get; set; } = DateTime.Now;
    public DateTime? DeliveredDate { get; set; }
    public DateTime? ReadDate { get; set; }
    public int? AttemptCount { get; set; } = 1;
    public DateTime? LastAttemptDate { get; set; }
    public string? MediaUrl { get; set; } // For messages with images/documents
    public int? CreatedByUserId { get; set; }
}
