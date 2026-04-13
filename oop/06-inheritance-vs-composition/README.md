# Inheritance vs Composition

## The Idea

Inheritance and composition are two ways to share behaviour between classes. Inheritance creates an "is-a" relationship: a SavingsAccount is a BankAccount. Composition creates a "has-a" relationship: a SavingsAccount has an InterestCalculator.

Both achieve code reuse, but they have different trade-offs.

## The Problem

Consider an account that earns interest. With inheritance, you might create a SavingsAccount that extends an InterestBearingAccount. But what happens when you need a cheque account that also earns interest? Multiple inheritance is not supported in C# or TypeScript, and duplicating the interest logic violates DRY.

## Inheritance Approach

The inheritance folder shows:
- InterestBearingAccount as a base class with interest logic
- SavingsAccount inherits from InterestBearingAccount

Pros:
- Simple for straightforward hierarchies
- Protected members are accessible

Cons:
- Tight coupling between parent and child
- Changes to the base class ripple through all subclasses
- Cannot mix behaviours from multiple base classes
- The hierarchy is fixed at compile time

## Composition Approach

The composition folder shows:
- InterestCalculator as a separate class injected into SavingsAccount
- SavingsAccount delegates interest calculations to the injected calculator

Pros:
- Loose coupling: the account and calculator can vary independently
- Behaviours can be swapped at runtime
- Easy to combine multiple behaviours
- Easier to test: calculators can be mocked

Cons:
- More classes and indirection
- Must explicitly delegate calls

## When to Use Each

Use inheritance when:
- The relationship is truly "is-a"
- The hierarchy is stable and unlikely to change
- Subclasses need access to protected members

Use composition when:
- You need flexibility to change behaviour at runtime
- Multiple classes need the same behaviour without a common ancestor
- You want to follow the principle "favour composition over inheritance"

In practice, composition is preferred for most cases. Inheritance should be reserved for modelling true specialisation, not just code reuse.

## Files

| File | Description |
|---|---|
| csharp/Inheritance/InterestBearingAccount.cs | Base class with interest logic |
| csharp/Inheritance/SavingsAccount.cs | Inherits interest behaviour |
| csharp/Composition/InterestCalculator.cs | Standalone interest calculator |
| csharp/Composition/SavingsAccount.cs | Uses injected calculator |
| typescript/inheritance/interestBearingAccount.ts | Base class with interest logic |
| typescript/inheritance/savingsAccount.ts | Inherits interest behaviour |
| typescript/composition/interestCalculator.ts | Standalone interest calculator |
| typescript/composition/savingsAccount.ts | Uses injected calculator |
