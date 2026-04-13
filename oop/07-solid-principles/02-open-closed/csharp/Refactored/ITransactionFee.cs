/*
 * Demonstrates: Open/Closed Principle - Refactored
 * Concept: Interface that allows new transaction types without modifying existing code
 */

namespace FinanceDomain.SOLID.OCP.Refactored;

public interface ITransactionFee
{
    string TransactionType { get; }
    decimal CalculateFee(decimal amount);
}
