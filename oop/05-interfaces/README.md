# Interfaces

## The Idea

An interface defines a contract: a set of methods and properties that a class must implement. Unlike abstract classes, interfaces contain no implementation. They specify what a class can do, not how it does it.

In banking, different entities share common behaviours. Bank accounts and payment terminals are both transactable. Bank accounts and loan agreements are both auditable. Interfaces allow unrelated classes to implement the same contract without sharing a common ancestor.

## What This Example Demonstrates

Two interfaces are defined:
- **ITransactable**: Requires Deposit, Withdraw, and Balance. Any class that handles money flow implements this.
- **IAuditable**: Requires GetAuditLog and RecordAudit. Any class that must track changes for compliance implements this.

Different classes implement these interfaces:
- BankAccount implements both ITransactable and IAuditable
- CashRegister implements only ITransactable
- LoanAgreement implements only IAuditable

A class can implement multiple interfaces, allowing it to fulfill multiple contracts.

## Why It Matters

Interfaces enable loose coupling. Code can depend on the interface rather than a specific class. A payment processor can work with any ITransactable, whether it is a bank account, cash register, or digital wallet.

Interfaces also support the Interface Segregation Principle: clients should not depend on methods they do not use. Instead of one large interface, multiple small interfaces allow classes to implement only what they need.

## Files

| File | Description |
|---|---|
| csharp/ITransactable.cs | Interface for money flow operations |
| csharp/IAuditable.cs | Interface for audit logging |
| csharp/BankAccount.cs | Implements both interfaces |
| csharp/CashRegister.cs | Implements ITransactable only |
| csharp/LoanAgreement.cs | Implements IAuditable only |
| typescript/transactable.ts | Interface for money flow operations |
| typescript/auditable.ts | Interface for audit logging |
| typescript/bankAccount.ts | Implements both interfaces |
| typescript/cashRegister.ts | Implements ITransactable only |
| typescript/loanAgreement.ts | Implements IAuditable only |
