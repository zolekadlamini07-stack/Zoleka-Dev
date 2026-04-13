/*
 * Demonstrates: Inheritance - Derived Class
 * Concept: SavingsAccount inherits from BankAccount and adds interest calculation
 */

namespace FinanceDomain.Inheritance;

public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; }

    public SavingsAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal interestRate)
        : base(accountNumber, accountHolder, openingBalance)
    {
        if (interestRate < 0 || interestRate > 1)
            throw new ArgumentException("Interest rate must be between 0 and 1.");

        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = _balance * InterestRate;
        _balance += interest;
        RecordTransaction($"Interest applied: +R{interest:F2} at {InterestRate:P2} | Balance: R{_balance:F2}");
    }

    public decimal CalculateInterest()
    {
        return _balance * InterestRate;
    }
}
