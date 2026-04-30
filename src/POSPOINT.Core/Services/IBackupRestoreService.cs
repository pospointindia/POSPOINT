namespace POSPOINT.Core.Services;

public interface IBackupRestoreService
{
    Task<string> CreateFullBackupAsync(string backupPath);
    Task<bool> RestoreFromBackupAsync(string backupFilePath);
    Task<IEnumerable<BackupInfo>> GetBackupHistoryAsync();
    Task<bool> DeleteBackupAsync(string backupFilePath);
}

public class BackupInfo
{
    public string BackupName { get; set; } = string.Empty;
    public string BackupPath { get; set; } = string.Empty;
    public long BackupSize { get; set; }
    public DateTime BackupDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
