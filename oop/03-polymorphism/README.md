# Polymorphism

## The Idea

Polymorphism means "many forms." It allows code to work with objects of different types through a common interface, without needing to know the specific type at compile time. The same method call behaves differently depending on the actual object type.

In banking, a transaction processor might need to withdraw funds from any account type. With polymorphism, the processor calls Withdraw() on any account, and each account type handles it appropriately: a savings account checks the balance, a cheque account allows overdraft, and a credit account checks the credit limit.

## What This Example Demonstrates

The example shows:
- A base Account class with a virtual ProcessTransaction method
- Three derived classes (SavingsAccount, ChequeAccount, CreditAccount) each overriding ProcessTransaction
- A TransactionProcessor that works with any Account without knowing its specific type
- The caller passes in Account references, and the correct implementation runs automatically

## Why It Matters

Polymorphism enables the Open/Closed Principle: code is open for extension but closed for modification. Adding a new account type requires only creating a new class that implements the interface. Existing code that processes accounts does not need to change.

This reduces coupling and makes systems easier to extend. The transaction processor does not contain switch statements or type checks. It simply calls the method, and the object handles the rest.

## Files

| File | Description |
|---|---|
| csharp/Account.cs | Base account class with virtual methods |
| csharp/SavingsAccount.cs | Savings account implementation |
| csharp/ChequeAccount.cs | Cheque account implementation |
| csharp/CreditAccount.cs | Credit account implementation |
| csharp/TransactionProcessor.cs | Processor that works with any account type |
| typescript/account.ts | Base account class |
| typescript/savingsAccount.ts | Savings account implementation |
| typescript/chequeAccount.ts | Cheque account implementation |
| typescript/creditAccount.ts | Credit account implementation |
| typescript/transactionProcessor.ts | Processor that works with any account type |
