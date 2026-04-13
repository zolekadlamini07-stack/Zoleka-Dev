/*
 * Demonstrates: Single Responsibility Principle - Refactored
 * Concept: BankAccount now only handles balance and transaction logic
 */

namespace FinanceDomain.SOLID.SRP.Refactored;

public class BankAccount
{
    private decimal _balance;
    private readonly List<Transaction> _transactions = [];

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance => _balance;
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public BankAccount(string accountNumber, string accountHolder, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        _transactions.Add(new Transaction(TransactionType.Opening, openingBalance, _balance));
    }

    public Transaction Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        _balance += amount;
        var transaction = new Transaction(TransactionType.Deposit, amount, _balance);
        _transactions.Add(transaction);
        return transaction;
    }

    public Transaction Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
        var transaction = new Transaction(TransactionType.Withdrawal, amount, _balance);
        _transactions.Add(transaction);
        return transaction;
    }
}

public class Transaction
{
    public TransactionType Type { get; }
    public decimal Amount { get; }
    public decimal BalanceAfter { get; }
    public DateTime Timestamp { get; }

    public Transaction(TransactionType type, decimal amount, decimal balanceAfter)
    {
        Type = type;
        Amount = amount;
        BalanceAfter = balanceAfter;
        Timestamp = DateTime.UtcNow;
    }
}

public enum TransactionType
{
    Opening,
    Deposit,
    Withdrawal
}
