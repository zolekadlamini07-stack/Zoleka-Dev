/*
 * Demonstrates: Polymorphism - Override
 * Concept: SavingsAccount overrides ProcessWithdrawal to enforce minimum balance
 */

namespace FinanceDomain.Polymorphism;

public class SavingsAccount : Account
{
    public decimal MinimumBalance { get; }

    public SavingsAccount(string accountNumber, string accountHolder, decimal openingBalance, decimal minimumBalance)
        : base(accountNumber, accountHolder, openingBalance)
    {
        MinimumBalance = minimumBalance;
    }

    public override TransactionResult ProcessWithdrawal(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.Failed("Amount must be greater than zero.");

        decimal resultingBalance = _balance - amount;

        if (resultingBalance < MinimumBalance)
            return TransactionResult.Failed($"Cannot withdraw. Minimum balance of R{MinimumBalance:F2} required.");

        _balance = resultingBalance;
        return TransactionResult.Succeeded($"Withdrew R{amount:F2}. New balance: R{_balance:F2}");
    }

    public override string GetAccountType() => "Savings Account";
}
