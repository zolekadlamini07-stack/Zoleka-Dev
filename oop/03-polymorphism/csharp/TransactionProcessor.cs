/*
 * Demonstrates: Polymorphism - Polymorphic Behaviour
 * Concept: Processor works with any Account type without knowing the specific implementation
 */

namespace FinanceDomain.Polymorphism;

public class TransactionProcessor
{
    public List<string> ProcessBatchWithdrawals(IEnumerable<Account> accounts, decimal amount)
    {
        var results = new List<string>();

        foreach (var account in accounts)
        {
            var result = account.ProcessWithdrawal(amount);
            var status = result.Success ? "SUCCESS" : "FAILED";
            results.Add($"[{account.GetAccountType()}] {account.AccountNumber}: {status} - {result.Message}");
        }

        return results;
    }

    public TransactionResult WithdrawFromAccount(Account account, decimal amount)
    {
        return account.ProcessWithdrawal(amount);
    }
}
