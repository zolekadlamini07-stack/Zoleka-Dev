/*
 * Demonstrates: Interface Segregation Principle - Refactored
 * Concept: Each account implements only the interfaces it needs
 */

namespace FinanceDomain.SOLID.ISP.Refactored;

public class BasicAccount : IAccount, IDepositable, IWithdrawable
{
    private decimal _balance;

    public string AccountNumber { get; }
    public decimal Balance => _balance;

    public BasicAccount(string accountNumber, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
    }
}

public class SavingsAccount : IAccount, IDepositable, IWithdrawable, IInterestBearing, IStatementProvider
{
    private decimal _balance;
    private readonly List<string> _transactions = [];

    public string AccountNumber { get; }
    public decimal Balance => _balance;
    public decimal InterestRate { get; }

    public SavingsAccount(string accountNumber, decimal openingBalance, decimal interestRate)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
        InterestRate = interestRate;
        _transactions.Add($"Opened with R{openingBalance:F2}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        _balance += amount;
        _transactions.Add($"Deposit: +R{amount:F2}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
        _transactions.Add($"Withdrawal: -R{amount:F2}");
    }

    public decimal CalculateInterest()
    {
        return _balance * InterestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = CalculateInterest();
        _balance += interest;
        _transactions.Add($"Interest: +R{interest:F2}");
    }

    public string GenerateStatement()
    {
        return $"Account: {AccountNumber}\nBalance: R{_balance:F2}\nTransactions:\n" +
               string.Join("\n", _transactions.Select(t => $"  {t}"));
    }
}

public class CurrentAccount : IAccount, IDepositable, IWithdrawable, ITransferable, IStatementProvider, INotifiable
{
    private decimal _balance;
    private readonly List<string> _transactions = [];
    private readonly Action<string> _notificationHandler;

    public string AccountNumber { get; }
    public decimal Balance => _balance;

    public CurrentAccount(string accountNumber, decimal openingBalance, Action<string> notificationHandler)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
        _notificationHandler = notificationHandler;
        _transactions.Add($"Opened with R{openingBalance:F2}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        _balance += amount;
        _transactions.Add($"Deposit: +R{amount:F2}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
        _transactions.Add($"Withdrawal: -R{amount:F2}");
    }

    public void Transfer(decimal amount, string toAccountNumber)
    {
        Withdraw(amount);
        _transactions.Add($"Transfer to {toAccountNumber}: -R{amount:F2}");
        SendNotification($"Transfer of R{amount:F2} to {toAccountNumber} completed.");
    }

    public string GenerateStatement()
    {
        return $"Account: {AccountNumber}\nBalance: R{_balance:F2}\nTransactions:\n" +
               string.Join("\n", _transactions.Select(t => $"  {t}"));
    }

    public void SendNotification(string message)
    {
        _notificationHandler(message);
    }
}
