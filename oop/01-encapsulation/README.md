# Encapsulation

## The Idea

Encapsulation means an object controls its own data. Nothing outside the object can reach in and change its internal state directly. Interaction happens only through methods the object deliberately exposes.

A bank account is a good analogy. You cannot change your balance directly. You can only deposit, withdraw, or request a statement, and the bank enforces the rules around each action.

## What This Example Demonstrates

The BankAccount class in this folder:
- Keeps balance private — nothing outside can read or write it directly
- Exposes a read-only Balance property
- Enforces business rules inside the class — no overdraft, no zero deposits
- Maintains a transaction history that is readable but not modifiable from outside
- Uses a factory method instead of a public constructor to control how accounts are created

## Why It Matters

In Clean Architecture, encapsulation keeps business rules from leaking into the wrong layer. If balance could be set from anywhere, a bug in one part of the system could silently corrupt data. Encapsulation means the rules live in one place.

## Files

| File | Language |
|---|---|
| csharp/BankAccount.cs | C# |
| typescript/BankAccount.ts | TypeScript |
