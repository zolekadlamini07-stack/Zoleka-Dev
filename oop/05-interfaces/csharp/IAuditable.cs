/*
 * Demonstrates: Interfaces - Contract Definition
 * Concept: IAuditable defines the contract for any class that must track changes for compliance
 */

namespace FinanceDomain.Interfaces;

public interface IAuditable
{
    IReadOnlyList<AuditEntry> GetAuditLog();
    void RecordAudit(string action, string details);
}

public class AuditEntry
{
    public DateTime Timestamp { get; }
    public string Action { get; }
    public string Details { get; }

    public AuditEntry(string action, string details)
    {
        Timestamp = DateTime.UtcNow;
        Action = action;
        Details = details;
    }

    public override string ToString() => $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Action}: {Details}";
}
