/*
 * Demonstrates: Interface Segregation Principle - Violation
 * Concept: One large interface forces implementers to provide many unrelated methods
 */

namespace FinanceDomain.SOLID.ISP.Violation;

public interface IAccountService
{
    string AccountNumber { get; }
    decimal Balance { get; }

    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void Transfer(decimal amount, string toAccountNumber);

    void ApplyInterest();
    decimal CalculateInterest();

    string GenerateStatement();
    string GenerateAnnualReport();

    void SendEmailNotification(string message);
    void SendSmsNotification(string message);

    decimal CalculateTax();
    void ReportToTaxAuthority();
}
