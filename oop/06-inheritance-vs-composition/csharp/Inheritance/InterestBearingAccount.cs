/*
 * Demonstrates: Inheritance vs Composition - Inheritance Approach
 * Concept: Base class that provides interest calculation behaviour through inheritance
 */

namespace FinanceDomain.InheritanceVsComposition.Inheritance;

public abstract class InterestBearingAccount
{
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    protected decimal _balance;
    public decimal InterestRate { get; }

    public decimal Balance => _balance;

    protected InterestBearingAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal interestRate)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        InterestRate = interestRate;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        _balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
    }

    public decimal CalculateInterest()
    {
        return _balance * InterestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = CalculateInterest();
        _balance += interest;
    }
}
