/*
 * Demonstrates: Interfaces - Single Interface Implementation
 * Concept: CashRegister implements only ITransactable as it does not require audit logging
 */

namespace FinanceDomain.Interfaces;

public class CashRegister : ITransactable
{
    private decimal _balance;

    public string RegisterId { get; }
    public decimal Balance => _balance;

    public CashRegister(string registerId, decimal openingFloat)
    {
        RegisterId = registerId;
        _balance = openingFloat;
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
            throw new InvalidOperationException($"Insufficient cash in register. Available: R{_balance:F2}");

        _balance -= amount;
    }

    public decimal CloseRegister()
    {
        decimal finalBalance = _balance;
        _balance = 0;
        return finalBalance;
    }
}
