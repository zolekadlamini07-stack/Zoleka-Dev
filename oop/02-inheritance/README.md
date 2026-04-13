# Inheritance

## The Idea

Inheritance allows a class to derive from another class, inheriting its properties and methods while adding or modifying behaviour. The derived class (child) is a more specific version of the base class (parent).

In banking, all accounts share common attributes like account number, holder name, and balance. However, a savings account earns interest while a cheque account may allow overdrafts. Inheritance lets us define the common behaviour once in a base class and specialize it in subclasses.

## What This Example Demonstrates

The BankAccount base class defines:
- Common properties: account number, holder, balance
- Common methods: deposit, withdraw, get statement
- Protected members that subclasses can access

SavingsAccount extends BankAccount and adds:
- Interest rate property
- Method to calculate and apply interest

ChequeAccount extends BankAccount and adds:
- Overdraft limit property
- Overridden withdraw method that allows negative balance up to the limit

## Why It Matters

Inheritance promotes code reuse and establishes clear hierarchies. When business rules apply to all account types, they live in the base class. When rules differ by account type, subclasses override or extend the base behaviour.

However, inheritance creates tight coupling. Changes to the base class affect all subclasses. For this reason, composition is often preferred for sharing behaviour. See the inheritance-vs-composition folder for a comparison.

## Files

| File | Description |
|---|---|
| csharp/BankAccount.cs | Base account class |
| csharp/SavingsAccount.cs | Savings account with interest |
| csharp/ChequeAccount.cs | Cheque account with overdraft |
| typescript/bankAccount.ts | Base account class |
| typescript/savingsAccount.ts | Savings account with interest |
| typescript/chequeAccount.ts | Cheque account with overdraft |
