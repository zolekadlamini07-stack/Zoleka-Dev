/*
 * Demonstrates: Inheritance vs Composition - Inheritance Approach
 * Concept: SavingsAccount inherits interest behaviour from InterestBearingAccount
 */

namespace FinanceDomain.InheritanceVsComposition.Inheritance;

public class SavingsAccount : InterestBearingAccount
{
    public decimal MinimumBalance { get; }

    public SavingsAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal interestRate, decimal minimumBalance)
        : base(accountNumber, accountHolder, openingBalance, interestRate)
    {
        MinimumBalance = minimumBalance;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        decimal resultingBalance = _balance - amount;

        if (resultingBalance < MinimumBalance)
            throw new InvalidOperationException($"Cannot withdraw. Minimum balance of R{MinimumBalance:F2} required.");

        _balance = resultingBalance;
    }
}
