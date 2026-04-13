/*
 * Demonstrates: Polymorphism - Base Class
 * Concept: Virtual methods that derived classes override to provide different behaviour
 */

namespace FinanceDomain.Polymorphism;

public class Account
{
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    protected decimal _balance;

    public decimal Balance => _balance;

    public Account(string accountNumber, string accountHolder, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        _balance = openingBalance;
    }

    public virtual TransactionResult ProcessWithdrawal(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.Failed("Amount must be greater than zero.");

        if (amount > _balance)
            return TransactionResult.Failed($"Insufficient funds. Available: R{_balance:F2}");

        _balance -= amount;
        return TransactionResult.Succeeded($"Withdrew R{amount:F2}. New balance: R{_balance:F2}");
    }

    public virtual string GetAccountType() => "Standard Account";
}

public class TransactionResult
{
    public bool Success { get; }
    public string Message { get; }

    private TransactionResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static TransactionResult Succeeded(string message) => new(true, message);
    public static TransactionResult Failed(string message) => new(false, message);
}
