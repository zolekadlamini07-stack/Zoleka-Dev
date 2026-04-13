/*
 * Demonstrates: Inheritance vs Composition - Composition Approach
 * Concept: Standalone InterestCalculator that can be injected into any account
 */

namespace FinanceDomain.InheritanceVsComposition.Composition;

public interface IInterestCalculator
{
    decimal CalculateInterest(decimal balance);
}

public class SimpleInterestCalculator : IInterestCalculator
{
    public decimal Rate { get; }

    public SimpleInterestCalculator(decimal rate)
    {
        if (rate < 0 || rate > 1)
            throw new ArgumentException("Rate must be between 0 and 1.");

        Rate = rate;
    }

    public decimal CalculateInterest(decimal balance)
    {
        return balance * Rate;
    }
}

public class TieredInterestCalculator : IInterestCalculator
{
    private readonly decimal _lowTierRate;
    private readonly decimal _highTierRate;
    private readonly decimal _threshold;

    public TieredInterestCalculator(decimal lowTierRate, decimal highTierRate, decimal threshold)
    {
        _lowTierRate = lowTierRate;
        _highTierRate = highTierRate;
        _threshold = threshold;
    }

    public decimal CalculateInterest(decimal balance)
    {
        if (balance <= _threshold)
            return balance * _lowTierRate;

        decimal lowTierInterest = _threshold * _lowTierRate;
        decimal highTierInterest = (balance - _threshold) * _highTierRate;

        return lowTierInterest + highTierInterest;
    }
}
