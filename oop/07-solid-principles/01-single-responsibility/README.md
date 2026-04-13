# Single Responsibility Principle (SRP)

## The Principle

A class should have only one reason to change. This means a class should have only one job or responsibility.

## The Problem

Consider a BankAccount class that:
- Manages account balance and transactions
- Formats statements for printing
- Sends email notifications
- Saves data to a database

This class has four reasons to change: business rules, formatting requirements, notification requirements, and persistence requirements. Changes to any of these could break the others.

## The Solution

Separate each responsibility into its own class:
- BankAccount: manages balance and transactions
- StatementFormatter: formats statements
- NotificationService: sends notifications
- AccountRepository: handles persistence

Each class now has one reason to change, and changes are isolated.

## What This Example Demonstrates

The example shows:
- A violation: a single class doing transaction processing, formatting, and notification
- A refactored version: separate classes for each responsibility
- How the refactored version is easier to test and modify

## Why It Matters

SRP makes code easier to understand because each class has a clear purpose. It makes testing easier because you can test each responsibility in isolation. It reduces the risk of breaking unrelated functionality when making changes.

## Files

| File | Description |
|---|---|
| csharp/Violation/BankAccount.cs | Class with multiple responsibilities |
| csharp/Refactored/BankAccount.cs | Account with single responsibility |
| csharp/Refactored/StatementFormatter.cs | Separate formatting responsibility |
| csharp/Refactored/TransactionNotifier.cs | Separate notification responsibility |
