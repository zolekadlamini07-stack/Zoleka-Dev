/*
 * Demonstrates: Inheritance vs Composition - Composition Approach
 * Concept: SavingsAccount uses an injected IInterestCalculator instead of inheriting interest behaviour
 */

namespace FinanceDomain.InheritanceVsComposition.Composition;

public class SavingsAccount
{
    private decimal _balance;
    private readonly IInterestCalculator _interestCalculator;

    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal MinimumBalance { get; }
    public decimal Balance => _balance;

    public SavingsAccount(
        string accountNumber,
        string accountHolder,
        decimal openingBalance,
        decimal minimumBalance,
        IInterestCalculator interestCalculator)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
        MinimumBalance = minimumBalance;
        _interestCalculator = interestCalculator;
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

        decimal resultingBalance = _balance - amount;

        if (resultingBalance < MinimumBalance)
            throw new InvalidOperationException($"Cannot withdraw. Minimum balance of R{MinimumBalance:F2} required.");

        _balance = resultingBalance;
    }

    public decimal CalculateInterest()
    {
        return _interestCalculator.CalculateInterest(_balance);
    }

    public void ApplyInterest()
    {
        decimal interest = CalculateInterest();
        _balance += interest;
    }
}
