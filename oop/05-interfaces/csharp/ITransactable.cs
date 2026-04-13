/*
 * Demonstrates: Interfaces - Contract Definition
 * Concept: ITransactable defines the contract for any class that handles money flow
 */

namespace FinanceDomain.Interfaces;

public interface ITransactable
{
    decimal Balance { get; }
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
}
