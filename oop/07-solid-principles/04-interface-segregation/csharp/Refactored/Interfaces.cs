/*
 * Demonstrates: Interface Segregation Principle - Refactored
 * Concept: Segregated interfaces for different account capabilities
 */

namespace FinanceDomain.SOLID.ISP.Refactored;

public interface IAccount
{
    string AccountNumber { get; }
    decimal Balance { get; }
}

public interface IDepositable
{
    void Deposit(decimal amount);
}

public interface IWithdrawable
{
    void Withdraw(decimal amount);
}

public interface ITransferable
{
    void Transfer(decimal amount, string toAccountNumber);
}

public interface IInterestBearing
{
    decimal InterestRate { get; }
    decimal CalculateInterest();
    void ApplyInterest();
}

public interface IStatementProvider
{
    string GenerateStatement();
}

public interface INotifiable
{
    void SendNotification(string message);
}
