/*
 * Demonstrates: Single Responsibility Principle - Refactored
 * Concept: TransactionNotifier has the single responsibility of sending notifications
 */

namespace FinanceDomain.SOLID.SRP.Refactored;

public interface ITransactionNotifier
{
    void Notify(string recipient, Transaction transaction);
}

public class EmailTransactionNotifier : ITransactionNotifier
{
    public void Notify(string recipient, Transaction transaction)
    {
        string message = transaction.Type switch
        {
            TransactionType.Deposit => $"Deposit of R{transaction.Amount:F2} received.",
            TransactionType.Withdrawal => $"Withdrawal of R{transaction.Amount:F2} processed.",
            _ => $"Transaction processed."
        };

        Console.WriteLine($"[EMAIL to {recipient}]: {message} Balance: R{transaction.BalanceAfter:F2}");
    }
}

public class SmsTransactionNotifier : ITransactionNotifier
{
    public void Notify(string recipient, Transaction transaction)
    {
        string message = transaction.Type switch
        {
            TransactionType.Deposit => $"Dep +R{transaction.Amount:F2}",
            TransactionType.Withdrawal => $"WDR -R{transaction.Amount:F2}",
            _ => "TXN"
        };

        Console.WriteLine($"[SMS to {recipient}]: {message} Bal: R{transaction.BalanceAfter:F2}");
    }
}
