/*
 * Demonstrates: Open/Closed Principle - Violation
 * Concept: This calculator must be modified every time a new transaction type is added
 */

namespace FinanceDomain.SOLID.OCP.Violation;

public class FeeCalculator
{
    public decimal CalculateFee(string transactionType, decimal amount)
    {
        return transactionType switch
        {
            "Deposit" => 0m,
            "Withdrawal" => 5m,
            "Transfer" => Math.Min(amount * 0.01m, 50m),
            "Payment" => 2.50m,
            _ => throw new ArgumentException($"Unknown transaction type: {transactionType}")
        };
    }
}
