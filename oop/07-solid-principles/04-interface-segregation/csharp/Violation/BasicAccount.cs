/*
 * Demonstrates: Interface Segregation Principle - Violation
 * Concept: BasicAccount is forced to implement methods it does not need
 */

namespace FinanceDomain.SOLID.ISP.Violation;

public class BasicAccount : IAccountService
{
    private decimal _balance;

    public string AccountNumber { get; }
    public decimal Balance => _balance;

    public BasicAccount(string accountNumber, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        _balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
    }

    public void Transfer(decimal amount, string toAccountNumber)
    {
        throw new NotSupportedException("Basic accounts do not support transfers.");
    }

    public void ApplyInterest()
    {
        throw new NotSupportedException("Basic accounts do not earn interest.");
    }

    public decimal CalculateInterest()
    {
        throw new NotSupportedException("Basic accounts do not earn interest.");
    }

    public string GenerateStatement()
    {
        throw new NotSupportedException("Basic accounts do not generate statements.");
    }

    public string GenerateAnnualReport()
    {
        throw new NotSupportedException("Basic accounts do not generate reports.");
    }

    public void SendEmailNotification(string message)
    {
        throw new NotSupportedException("Basic accounts do not send notifications.");
    }

    public void SendSmsNotification(string message)
    {
        throw new NotSupportedException("Basic accounts do not send notifications.");
    }

    public decimal CalculateTax()
    {
        throw new NotSupportedException("Basic accounts do not calculate tax.");
    }

    public void ReportToTaxAuthority()
    {
        throw new NotSupportedException("Basic accounts do not report to tax authority.");
    }
}
