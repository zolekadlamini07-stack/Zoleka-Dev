/*
 * Demonstrates: Polymorphism - Override
 * Concept: CreditAccount overrides ProcessWithdrawal to check credit limit
 */

namespace FinanceDomain.Polymorphism;

public class CreditAccount : Account
{
    public decimal CreditLimit { get; }

    public CreditAccount(string accountNumber, string accountHolder, decimal creditLimit)
        : base(accountNumber, accountHolder, 0)
    {
        CreditLimit = creditLimit;
    }

    public override TransactionResult ProcessWithdrawal(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.Failed("Amount must be greater than zero.");

        decimal currentDebt = Math.Abs(_balance);
        decimal availableCredit = CreditLimit - currentDebt;

        if (amount > availableCredit)
            return TransactionResult.Failed($"Exceeds credit limit. Available credit: R{availableCredit:F2}");

        _balance -= amount;
        return TransactionResult.Succeeded($"Charged R{amount:F2}. Outstanding balance: R{Math.Abs(_balance):F2}");
    }

    public override string GetAccountType() => "Credit Account";

    public decimal AvailableCredit => CreditLimit - Math.Abs(_balance);
}
