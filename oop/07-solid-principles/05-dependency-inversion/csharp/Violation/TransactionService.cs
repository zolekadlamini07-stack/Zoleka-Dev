/*
 * Demonstrates: Dependency Inversion Principle - Violation
 * Concept: High-level TransactionService directly depends on low-level SqlDatabase
 */

namespace FinanceDomain.SOLID.DIP.Violation;

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

public class SqlDatabase
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

    public List<Transaction> GetByAccount(string accountNumber)
    {
        Console.WriteLine($"[SQL] Retrieving transactions for account {accountNumber}...");
        return [];
    }
}

public class EmailService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"[EMAIL] Sending to {recipient}: {message}");
    }
}

public class TransactionService
{
    private readonly SqlDatabase _database = new();
    private readonly EmailService _emailService = new();

    public void ProcessTransaction(string accountNumber, decimal amount, string type, string notificationEmail)
    {
        var transaction = new Transaction(accountNumber, amount, type);

        _database.Save(transaction);

        _emailService.SendNotification(
            notificationEmail,
            $"Transaction {transaction.Id} processed: {type} of R{amount:F2}"
        );
    }

    public List<Transaction> GetAccountTransactions(string accountNumber)
    {
        return _database.GetByAccount(accountNumber);
    }
}
