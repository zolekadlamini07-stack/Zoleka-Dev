/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: ChequeAccount implements all abstract methods from Account
 */

namespace FinanceDomain.Abstraction;

public class ChequeAccount : Account
{
    public decimal OverdraftLimit { get; }
    public int TransactionCount { get; private set; }
    private const decimal FeePerTransaction = 2.50m;

    public ChequeAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal overdraftLimit)
        : base(accountNumber, accountHolder, openingBalance)
    {
        OverdraftLimit = overdraftLimit;
        TransactionCount = 0;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        decimal availableFunds = _balance + OverdraftLimit;

        if (amount > availableFunds)
            throw new InvalidOperationException($"Exceeds overdraft limit. Available: R{availableFunds:F2}");

        _balance -= amount;
        TransactionCount++;
    }

    public override decimal CalculateMonthlyFees()
    {
        return TransactionCount * FeePerTransaction;
    }

    public override string GetAccountSummary()
    {
        return $"Cheque Account {AccountNumber} | Holder: {AccountHolder} | Balance: R{_balance:F2} | Overdraft: R{OverdraftLimit:F2} | Transactions: {TransactionCount}";
    }

    public void ResetTransactionCount()
    {
        TransactionCount = 0;
    }
}
