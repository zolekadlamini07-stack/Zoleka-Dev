/*
 * Demonstrates: Single Responsibility Principle - Violation
 * Concept: This class has multiple responsibilities: transaction logic, formatting, and notification
 */

namespace FinanceDomain.SOLID.SRP.Violation;

public class BankAccount
{
    private decimal _balance;
    private readonly List<string> _transactions = [];

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public string Email { get; }
    public decimal Balance => _balance;

    public BankAccount(string accountNumber, string accountHolder, string email, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Email = email;
        _balance = openingBalance;
        _transactions.Add($"Account opened with R{openingBalance:F2}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        _balance += amount;
        _transactions.Add($"Deposit: +R{amount:F2}");

        SendEmailNotification($"Deposit of R{amount:F2} received. New balance: R{_balance:F2}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
        _transactions.Add($"Withdrawal: -R{amount:F2}");

        SendEmailNotification($"Withdrawal of R{amount:F2} processed. New balance: R{_balance:F2}");
    }

    public string GetFormattedStatement()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("========================================");
        sb.AppendLine($"BANK STATEMENT");
        sb.AppendLine($"Account: {AccountNumber}");
        sb.AppendLine($"Holder: {AccountHolder}");
        sb.AppendLine("========================================");
        sb.AppendLine("TRANSACTIONS:");
        foreach (var transaction in _transactions)
        {
            sb.AppendLine($"  {transaction}");
        }
        sb.AppendLine("========================================");
        sb.AppendLine($"CURRENT BALANCE: R{_balance:F2}");
        sb.AppendLine("========================================");
        return sb.ToString();
    }

    private void SendEmailNotification(string message)
    {
        Console.WriteLine($"[EMAIL to {Email}]: {message}");
    }
}
