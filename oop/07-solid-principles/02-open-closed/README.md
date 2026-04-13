# Open/Closed Principle (OCP)

## The Principle

Software entities (classes, modules, functions) should be open for extension but closed for modification. You should be able to add new behaviour without changing existing code.

## The Problem

Consider a transaction fee calculator with a switch statement:

```csharp
decimal fee = transactionType switch
{
    "Deposit" => 0,
    "Withdrawal" => 5,
    "Transfer" => 10,
    _ => throw new Exception("Unknown type")
};
```

Every time a new transaction type is added, this code must be modified. This risks breaking existing functionality and requires retesting the entire calculator.

## The Solution

Define an abstraction (interface or abstract class) and create implementations for each type. New types are added by creating new classes, not by modifying existing code.

## What This Example Demonstrates

The example shows:
- A violation: fee calculator with switch statement that must be modified for each new transaction type
- A refactored version: each transaction type implements IFeeCalculator, new types are added without modifying existing code

## Why It Matters

OCP reduces risk when adding features. Existing, tested code remains unchanged. New functionality is added through new classes that can be tested in isolation. This is particularly valuable in large systems where modifying core logic can have far-reaching consequences.

## Files

| File | Description |
|---|---|
| csharp/Violation/FeeCalculator.cs | Calculator that requires modification for new types |
| csharp/Refactored/ITransactionFee.cs | Interface for transaction fees |
| csharp/Refactored/TransactionTypes.cs | Implementations for each transaction type |
| csharp/Refactored/FeeCalculator.cs | Calculator that works with any ITransactionFee |
