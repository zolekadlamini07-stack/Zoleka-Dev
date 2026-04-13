/*
 * Demonstrates: Dependency Inversion Principle - Refactored
 * Concept: Abstractions that both high-level and low-level modules depend on
 */

namespace FinanceDomain.SOLID.DIP.Refactored;

public class Transaction
{
    public string Id { get; }
    public string AccountNumber { get; }
    public decimal Amount { get; }
    public string Type { get; }
    public DateTime Timestamp { get; }

    public Transaction(string accountNumber, decimal amount, string type)
    {
        Id = Guid.NewGuid().ToString();
        AccountNumber = accountNumber;
        Amount = amount;
        Type = type;
        Timestamp = DateTime.UtcNow;
    }
}

public interface ITransactionRepository
{
    void Save(Transaction transaction);
    Transaction? GetById(string id);
    IEnumerable<Transaction> GetByAccount(string accountNumber);
}

public interface INotificationService
{
    void SendNotification(string recipient, string message);
}
