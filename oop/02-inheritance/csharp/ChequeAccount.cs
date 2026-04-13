/*
 * Demonstrates: Inheritance - Derived Class with Override
 * Concept: ChequeAccount inherits from BankAccount and overrides Withdraw to allow overdraft
 */

namespace FinanceDomain.Inheritance;

public class ChequeAccount : BankAccount
{
    public decimal OverdraftLimit { get; }

    public ChequeAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal overdraftLimit)
        : base(accountNumber, accountHolder, openingBalance)
    {
        if (overdraftLimit < 0)
            throw new ArgumentException("Overdraft limit cannot be negative.");

        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        decimal availableFunds = _balance + OverdraftLimit;

        if (amount > availableFunds)
            throw new InvalidOperationException($"Exceeds overdraft limit. Available: R{availableFunds:F2}");

        _balance -= amount;
        RecordTransaction($"Withdrawal: -R{amount:F2} | Balance: R{_balance:F2}");
    }

    public decimal AvailableFunds => _balance + OverdraftLimit;
}
