/*
 * Demonstrates: Inheritance - Base Class
 * Concept: A base BankAccount class that SavingsAccount and ChequeAccount inherit from
 */

namespace FinanceDomain.Inheritance;

public class BankAccount
{
    private readonly List<string> _transactionHistory = [];

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    protected decimal _balance;

    public decimal Balance => _balance;
    public IReadOnlyList<string> TransactionHistory => _transactionHistory.AsReadOnly();

    public BankAccount(string accountNumber, string accountHolder, decimal openingBalance)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number is required.");

        if (string.IsNullOrWhiteSpace(accountHolder))
            throw new ArgumentException("Account holder name is required.");

        if (openingBalance < 0)
            throw new ArgumentException("Opening balance cannot be negative.");

        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        RecordTransaction($"Account opened with R{openingBalance:F2}");
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;
        RecordTransaction($"Deposit: +R{amount:F2} | Balance: R{_balance:F2}");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
        RecordTransaction($"Withdrawal: -R{amount:F2} | Balance: R{_balance:F2}");
    }

    protected void RecordTransaction(string entry)
    {
        _transactionHistory.Add(entry);
    }

    public string GetStatement()
    {
        var lines = new List<string>
        {
            $"=== Statement: {AccountHolder} ({AccountNumber}) ==="
        };

        lines.AddRange(_transactionHistory);
        lines.Add($"=== Current Balance: R{_balance:F2} ===");

        return string.Join(Environment.NewLine, lines);
    }
}
