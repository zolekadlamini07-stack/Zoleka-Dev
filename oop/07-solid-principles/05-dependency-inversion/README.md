# Dependency Inversion Principle (DIP)

## The Principle

High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

## The Problem

Consider a TransactionService that directly creates and uses a SqlDatabase object:

```csharp
class TransactionService
{
    private readonly SqlDatabase _database = new SqlDatabase();

    public void ProcessTransaction(Transaction transaction)
    {
        _database.Save(transaction);
    }
}
```

TransactionService (high-level) depends directly on SqlDatabase (low-level). To change the database, you must modify TransactionService. Testing requires a real database.

## The Solution

Introduce an abstraction (ITransactionRepository) that both depend on. TransactionService depends on the interface, and SqlDatabase implements the interface. The dependency direction is inverted: the low-level module now depends on the abstraction defined by the high-level module.

## What This Example Demonstrates

The example shows:
- A violation: TransactionService directly instantiates and depends on concrete implementations
- A refactored version: TransactionService depends on ITransactionRepository, which can be implemented by any storage mechanism

## Why It Matters

DIP enables:
- Testability: inject mock repositories for unit testing
- Flexibility: swap implementations without changing business logic
- Decoupling: high-level policy is independent of low-level details

DIP is foundational to Clean Architecture, where the domain layer defines interfaces and outer layers implement them.

## Files

| File | Description |
|---|---|
| csharp/Violation/TransactionService.cs | Service with direct dependency on concrete database |
| csharp/Refactored/ITransactionRepository.cs | Abstraction for transaction storage |
| csharp/Refactored/Repositories.cs | Different repository implementations |
| csharp/Refactored/TransactionService.cs | Service depending on abstraction |
