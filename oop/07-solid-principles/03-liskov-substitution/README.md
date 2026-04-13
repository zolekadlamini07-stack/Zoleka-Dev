# Liskov Substitution Principle (LSP)

## The Principle

Objects of a superclass should be replaceable with objects of its subclasses without breaking the application. Subtypes must be substitutable for their base types.

## The Problem

Consider a base Account class with a Withdraw method. A FixedDepositAccount inherits from Account but throws an exception when Withdraw is called because fixed deposits cannot be withdrawn early.

Code that works with Account objects will break when given a FixedDepositAccount. The subclass is not substitutable for the base class.

## The Solution

Design inheritance hierarchies so that subclasses honour the contracts of their base classes. If a subclass cannot fulfil the base class contract, it should not inherit from that class.

In this case, create separate abstractions: IWithdrawable for accounts that support withdrawal, and IAccount for general account behaviour.

## What This Example Demonstrates

The example shows:
- A violation: FixedDepositAccount inherits from Account but breaks the Withdraw contract
- A refactored version: separate interfaces for withdrawable and non-withdrawable accounts

## Why It Matters

LSP ensures that code using base class references continues to work correctly with any derived class. Violating LSP leads to runtime errors and defensive code that checks types before calling methods. Following LSP enables true polymorphism.

## Files

| File | Description |
|---|---|
| csharp/Violation/Account.cs | Base class and violating FixedDepositAccount |
| csharp/Refactored/IAccount.cs | Interfaces for different account capabilities |
| csharp/Refactored/Accounts.cs | Account implementations that honour their contracts |
