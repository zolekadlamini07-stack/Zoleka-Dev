/*
 * Demonstrates: Interfaces - Multiple Interface Implementation
 * Concept: BankAccount implements both ITransactable and IAuditable
 */

namespace FinanceDomain.Interfaces;

public class BankAccount : ITransactable, IAuditable
{
    private decimal _balance;
    private readonly List<AuditEntry> _auditLog = [];

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance => _balance;

    public BankAccount(string accountNumber, string accountHolder, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        RecordAudit("ACCOUNT_OPENED", $"Opening balance: R{openingBalance:F2}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;
        RecordAudit("DEPOSIT", $"Amount: R{amount:F2} | New Balance: R{_balance:F2}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
        RecordAudit("WITHDRAWAL", $"Amount: R{amount:F2} | New Balance: R{_balance:F2}");
    }

    public IReadOnlyList<AuditEntry> GetAuditLog() => _auditLog.AsReadOnly();

    public void RecordAudit(string action, string details)
    {
        _auditLog.Add(new AuditEntry(action, details));
    }
}
