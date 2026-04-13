# Abstraction

## The Idea

Abstraction means hiding implementation details and exposing only the essential features. It defines what an object does without specifying how it does it. Abstract classes provide a template that subclasses must complete.

In banking, every account must be able to calculate fees, but the fee structure differs: savings accounts might have no monthly fee, cheque accounts charge per transaction, and credit accounts charge interest on outstanding balances. An abstract Account class can require a CalculateFees method without implementing it.

## What This Example Demonstrates

The abstract Account class defines:
- Common implemented methods that all accounts share
- Abstract methods that each account type must implement differently
- A mix of concrete and abstract members

Each derived class (SavingsAccount, ChequeAccount, CreditAccount) provides its own implementation of the abstract methods, ensuring consistency while allowing flexibility.

## Abstract Classes vs Interfaces

Abstract classes can contain both implemented methods and abstract methods. They represent an "is-a" relationship and can hold state. A class can inherit from only one abstract class.

Interfaces define a contract with no implementation. They represent a "can-do" relationship and cannot hold state. A class can implement multiple interfaces.

Use abstract classes when subclasses share significant behaviour and state. Use interfaces when unrelated classes need to fulfill the same contract.

## Files

| File | Description |
|---|---|
| csharp/Account.cs | Abstract base class with abstract and concrete methods |
| csharp/SavingsAccount.cs | Implements abstract methods for savings logic |
| csharp/ChequeAccount.cs | Implements abstract methods for cheque logic |
| csharp/CreditAccount.cs | Implements abstract methods for credit logic |
| typescript/account.ts | Abstract base class |
| typescript/savingsAccount.ts | Savings implementation |
| typescript/chequeAccount.ts | Cheque implementation |
| typescript/creditAccount.ts | Credit implementation |
