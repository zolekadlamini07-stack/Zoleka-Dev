/*
 * Demonstrates: Open/Closed Principle - Refactored
 * Concept: Each transaction type implements ITransactionFee with its own fee logic
 */

namespace FinanceDomain.SOLID.OCP.Refactored;

public class DepositFee : ITransactionFee
{
    public string TransactionType => "Deposit";

    public decimal CalculateFee(decimal amount)
    {
        return 0m;
    }
}

public class WithdrawalFee : ITransactionFee
{
    public string TransactionType => "Withdrawal";

    public decimal CalculateFee(decimal amount)
    {
        return 5m;
    }
}

public class TransferFee : ITransactionFee
{
    public string TransactionType => "Transfer";
    private const decimal FeePercentage = 0.01m;
    private const decimal MaxFee = 50m;

    public decimal CalculateFee(decimal amount)
    {
        return Math.Min(amount * FeePercentage, MaxFee);
    }
}

public class PaymentFee : ITransactionFee
{
    public string TransactionType => "Payment";

    public decimal CalculateFee(decimal amount)
    {
        return 2.50m;
    }
}

public class InternationalTransferFee : ITransactionFee
{
    public string TransactionType => "InternationalTransfer";
    private const decimal FeePercentage = 0.025m;
    private const decimal MinFee = 25m;

    public decimal CalculateFee(decimal amount)
    {
        return Math.Max(amount * FeePercentage, MinFee);
    }
}
