/*
 * Demonstrates: Open/Closed Principle - Refactored
 * Concept: Calculator works with any ITransactionFee without modification
 */

namespace FinanceDomain.SOLID.OCP.Refactored;

public class FeeCalculator
{
    private readonly Dictionary<string, ITransactionFee> _feeStrategies;

    public FeeCalculator(IEnumerable<ITransactionFee> feeStrategies)
    {
        _feeStrategies = feeStrategies.ToDictionary(f => f.TransactionType, f => f);
    }

    public decimal CalculateFee(string transactionType, decimal amount)
    {
        if (!_feeStrategies.TryGetValue(transactionType, out var strategy))
            throw new ArgumentException($"Unknown transaction type: {transactionType}");

        return strategy.CalculateFee(amount);
    }

    public void RegisterFeeStrategy(ITransactionFee feeStrategy)
    {
        _feeStrategies[feeStrategy.TransactionType] = feeStrategy;
    }
}
