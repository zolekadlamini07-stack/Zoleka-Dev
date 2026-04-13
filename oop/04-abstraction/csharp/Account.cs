/*
 * Demonstrates: Abstraction - Abstract Class
 * Concept: Abstract class with both implemented and abstract methods that subclasses must override
 */

namespace FinanceDomain.Abstraction;

public abstract class Account
{
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    protected decimal _balance;

    public decimal Balance => _balance;

    protected Account(string accountNumber, string accountHolder, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;
    }

    public abstract void Withdraw(decimal amount);

    public abstract decimal CalculateMonthlyFees();

    public abstract string GetAccountSummary();

    public void ApplyMonthlyFees()
    {
        decimal fees = CalculateMonthlyFees();
        if (fees > 0)
        {
            _balance -= fees;
        }
    }
}
