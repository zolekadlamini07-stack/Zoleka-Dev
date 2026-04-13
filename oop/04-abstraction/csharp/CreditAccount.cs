/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: CreditAccount implements all abstract methods from Account
 */

namespace FinanceDomain.Abstraction;

public class CreditAccount : Account
{
    public decimal CreditLimit { get; }
    public decimal InterestRate { get; }

    public CreditAccount(string accountNumber, string accountHolder, decimal creditLimit, decimal interestRate)
        : base(accountNumber, accountHolder, 0)
    {
        CreditLimit = creditLimit;
        InterestRate = interestRate;
    }

    public decimal OutstandingBalance => Math.Abs(Math.Min(_balance, 0));
    public decimal AvailableCredit => CreditLimit - OutstandingBalance;

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > AvailableCredit)
            throw new InvalidOperationException($"Exceeds credit limit. Available: R{AvailableCredit:F2}");

        _balance -= amount;
    }

    public override decimal CalculateMonthlyFees()
    {
        return OutstandingBalance * InterestRate;
    }

    public override string GetAccountSummary()
    {
        return $"Credit Account {AccountNumber} | Holder: {AccountHolder} | Outstanding: R{OutstandingBalance:F2} | Available Credit: R{AvailableCredit:F2}";
    }

    public void MakePayment(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Payment amount must be greater than zero.");

        _balance += amount;
    }
}
