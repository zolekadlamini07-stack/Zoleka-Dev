# Interface Segregation Principle (ISP)

## The Principle

Clients should not be forced to depend on methods they do not use. Many small, specific interfaces are better than one large, general-purpose interface.

## The Problem

Consider a large IAccountService interface:

```csharp
interface IAccountService
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void Transfer(decimal amount, string toAccount);
    void ApplyInterest();
    void GenerateStatement();
    void SendNotification();
    void CalculateTax();
}
```

A basic savings account needs Deposit, Withdraw, and ApplyInterest. But implementing IAccountService forces it to provide implementations for Transfer, GenerateStatement, SendNotification, and CalculateTax, even if those are not relevant.

## The Solution

Split the large interface into smaller, focused interfaces. Classes implement only the interfaces they need.

## What This Example Demonstrates

The example shows:
- A violation: one large interface that forces implementers to provide unused methods
- A refactored version: multiple focused interfaces that classes can implement selectively

## Why It Matters

ISP reduces coupling. When a class depends on an interface, changes to that interface can force recompilation and potential changes. Smaller interfaces mean fewer unnecessary dependencies. Classes are simpler because they only implement what they actually need.

## Files

| File | Description |
|---|---|
| csharp/Violation/IAccountService.cs | Large interface with many unrelated methods |
| csharp/Violation/BasicAccount.cs | Account forced to implement unused methods |
| csharp/Refactored/Interfaces.cs | Segregated interfaces for different capabilities |
| csharp/Refactored/Accounts.cs | Accounts implementing only relevant interfaces |
