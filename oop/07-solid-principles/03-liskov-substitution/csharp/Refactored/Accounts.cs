/*
 * Demonstrates: Liskov Substitution Principle - Refactored
 * Concept: Each account implements only the interfaces it can honour
 */

namespace FinanceDomain.SOLID.LSP.Refactored;

public class SavingsAccount : IAccount, IWithdrawable
{
    private decimal _balance;

    public string AccountNumber { get; }
    public decimal Balance => _balance;

    public SavingsAccount(string accountNumber, decimal openingBalance)
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

public class FixedDepositAccount : IAccount
{
    private decimal _balance;

    public string AccountNumber { get; }
    public decimal Balance => _balance;
    public DateTime MaturityDate { get; }

    public FixedDepositAccount(string accountNumber, decimal openingBalance, DateTime maturityDate)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
        MaturityDate = maturityDate;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        _balance += amount;
    }

    public decimal CalculateMaturityValue(decimal interestRate)
    {
        var years = (MaturityDate - DateTime.UtcNow).TotalDays / 365;
        return _balance * (1 + interestRate * (decimal)years);
    }
}

public class TransactionProcessor
{
    public void ProcessWithdrawal(IWithdrawable account, decimal amount)
    {
        account.Withdraw(amount);
    }

    public void ProcessDeposit(IAccount account, decimal amount)
    {
        account.Deposit(amount);
    }
}
