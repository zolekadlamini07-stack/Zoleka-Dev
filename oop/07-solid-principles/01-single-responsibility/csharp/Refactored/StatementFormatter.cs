/*
 * Demonstrates: Single Responsibility Principle - Refactored
 * Concept: StatementFormatter has the single responsibility of formatting account statements
 */

namespace FinanceDomain.SOLID.SRP.Refactored;

public class StatementFormatter
{
    public string Format(BankAccount account)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("========================================");
        sb.AppendLine("BANK STATEMENT");
        sb.AppendLine($"Account: {account.AccountNumber}");
        sb.AppendLine($"Holder: {account.AccountHolder}");
        sb.AppendLine("========================================");
        sb.AppendLine("TRANSACTIONS:");

        foreach (var transaction in account.Transactions)
        {
            string sign = transaction.Type == TransactionType.Withdrawal ? "-" : "+";
            sb.AppendLine($"  [{transaction.Timestamp:yyyy-MM-dd}] {transaction.Type}: {sign}R{transaction.Amount:F2}");
        }

        sb.AppendLine("========================================");
        sb.AppendLine($"CURRENT BALANCE: R{account.Balance:F2}");
        sb.AppendLine("========================================");

        return sb.ToString();
    }
}
