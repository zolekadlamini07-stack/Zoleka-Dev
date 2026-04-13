/*
 * Demonstrates: Encapsulation
 * Concept: Private state, controlled access through methods, factory method for creation
 */

namespace FinanceDomain.Encapsulation;

public class BankAccount
{
    private decimal _balance;
    private readonly List<string> _transactionHistory = [];

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance => _balance;
    public IReadOnlyList<string> TransactionHistory => _transactionHistory.AsReadOnly();

    private BankAccount(string accountNumber, string accountHolder, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        _transactionHistory.Add($"Account opened with R{openingBalance:F2}");
    }

    public static BankAccount Create(string accountNumber, string accountHolder, decimal openingBalance)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number is required.");

        if (string.IsNullOrWhiteSpace(accountHolder))
            throw new ArgumentException("Account holder name is required.");

        if (openingBalance < 0)
            throw new ArgumentException("Opening balance cannot be negative.");

        return new BankAccount(accountNumber, accountHolder, openingBalance);
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;
        _transactionHistory.Add($"Deposit: +R{amount:F2} | Balance: R{_balance:F2}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
        _transactionHistory.Add($"Withdrawal: -R{amount:F2} | Balance: R{_balance:F2}");
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
