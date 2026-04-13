/*
 * Demonstrates: Polymorphism - Override
 * Concept: ChequeAccount overrides ProcessWithdrawal to allow overdraft
 */

namespace FinanceDomain.Polymorphism;

public class ChequeAccount : Account
{
    public decimal OverdraftLimit { get; }

    public ChequeAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal overdraftLimit)
        : base(accountNumber, accountHolder, openingBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override TransactionResult ProcessWithdrawal(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.Failed("Amount must be greater than zero.");

        decimal availableFunds = _balance + OverdraftLimit;

        if (amount > availableFunds)
            return TransactionResult.Failed($"Exceeds overdraft limit. Available: R{availableFunds:F2}");

        _balance -= amount;
        return TransactionResult.Succeeded($"Withdrew R{amount:F2}. New balance: R{_balance:F2}");
    }

    public override string GetAccountType() => "Cheque Account";
}
