/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: SavingsAccount implements all abstract methods from Account
 */

namespace FinanceDomain.Abstraction;

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }
    private const decimal MonthlyFee = 0m;

    public SavingsAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal interestRate)
        : base(accountNumber, accountHolder, openingBalance)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
    }

    public override decimal CalculateMonthlyFees()
    {
        return MonthlyFee;
    }

    public override string GetAccountSummary()
    {
        return $"Savings Account {AccountNumber} | Holder: {AccountHolder} | Balance: R{_balance:F2} | Interest Rate: {InterestRate:P2}";
    }

    public void ApplyInterest()
    {
        decimal interest = _balance * InterestRate;
        _balance += interest;
    }
}
