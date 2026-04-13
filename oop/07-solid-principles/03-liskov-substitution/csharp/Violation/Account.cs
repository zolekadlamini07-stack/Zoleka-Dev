/*
 * Demonstrates: Liskov Substitution Principle - Violation
 * Concept: FixedDepositAccount inherits from Account but breaks the Withdraw contract
 */

namespace FinanceDomain.SOLID.LSP.Violation;

public class Account
{
    protected decimal _balance;

    public string AccountNumber { get; }
    public decimal Balance => _balance;

    public Account(string accountNumber, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
    }

    public virtual void Deposit(decimal amount)
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
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
    }
}

public class FixedDepositAccount : Account
{
    public DateTime MaturityDate { get; }

    public FixedDepositAccount(string accountNumber, decimal openingBalance, DateTime maturityDate)
        : base(accountNumber, openingBalance)
    {
        MaturityDate = maturityDate;
    }

    public override void Withdraw(decimal amount)
    {
        throw new InvalidOperationException("Cannot withdraw from fixed deposit before maturity.");
    }
}
