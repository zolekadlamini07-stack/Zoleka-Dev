/*
 * Demonstrates: Liskov Substitution Principle - Refactored
 * Concept: Separate interfaces for different account capabilities
 */

namespace FinanceDomain.SOLID.LSP.Refactored;

public interface IAccount
{
    string AccountNumber { get; }
    decimal Balance { get; }
    void Deposit(decimal amount);
}

public interface IWithdrawable
{
    void Withdraw(decimal amount);
}
