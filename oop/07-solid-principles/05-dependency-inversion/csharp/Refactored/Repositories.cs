/*
 * Demonstrates: Dependency Inversion Principle - Refactored
 * Concept: Concrete implementations that depend on the abstractions
 */

namespace FinanceDomain.SOLID.DIP.Refactored;

public class SqlTransactionRepository : ITransactionRepository
{
    public void Save(Transaction transaction)
    {
        Console.WriteLine($"[SQL] Saving transaction {transaction.Id} to database...");
    }

    public Transaction? GetById(string id)
    {
        Console.WriteLine($"[SQL] Retrieving transaction {id} from database...");
        return null;
    }

    public IEnumerable<Transaction> GetByAccount(string accountNumber)
    {
        Console.WriteLine($"[SQL] Retrieving transactions for account {accountNumber}...");
        return [];
    }
}

public class InMemoryTransactionRepository : ITransactionRepository
{
    private readonly Dictionary<string, Transaction> _transactions = [];

    public void Save(Transaction transaction)
    {
        _transactions[transaction.Id] = transaction;
    }

    public Transaction? GetById(string id)
    {
        return _transactions.GetValueOrDefault(id);
    }

    public IEnumerable<Transaction> GetByAccount(string accountNumber)
    {
        return _transactions.Values.Where(t => t.AccountNumber == accountNumber);
    }
}

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"[EMAIL] Sending to {recipient}: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"[SMS] Sending to {recipient}: {message}");
    }
}

public class NullNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
    }
}
