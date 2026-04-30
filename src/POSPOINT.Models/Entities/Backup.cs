namespace POSPOINT.Models.Entities;

public class Backup
{
    public int BackupId { get; set; }
    public string BackupName { get; set; } = string.Empty;
    public string BackupPath { get; set; } = string.Empty;
    public long BackupSize { get; set; } // in bytes
    public DateTime BackupDate { get; set; } = DateTime.Now;
    public string BackupType { get; set; } = "Full"; // Full, Incremental, Differential
    public string Status { get; set; } = "Completed"; // In Progress, Completed, Failed
    public string? ErrorMessage { get; set; }
}
