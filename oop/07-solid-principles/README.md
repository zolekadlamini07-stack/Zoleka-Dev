# SOLID Principles

## Overview

SOLID is an acronym for five design principles that make software more maintainable, flexible, and understandable. These principles guide how classes should be structured and how they should interact.

| Principle | Summary |
|---|---|
| Single Responsibility | A class should have only one reason to change |
| Open/Closed | Open for extension, closed for modification |
| Liskov Substitution | Subtypes must be substitutable for their base types |
| Interface Segregation | Clients should not depend on methods they do not use |
| Dependency Inversion | Depend on abstractions, not concretions |

## Subfolders

Each principle has its own folder with a README explaining the concept and a C# example using the finance domain.

- 01-single-responsibility/
- 02-open-closed/
- 03-liskov-substitution/
- 04-interface-segregation/
- 05-dependency-inversion/

## Why SOLID Matters

These principles are not rules to follow blindly. They are guidelines that help identify code smells and suggest refactoring directions. Applying them thoughtfully leads to code that is easier to test, extend, and maintain.

Over-applying SOLID can lead to unnecessary abstraction. The goal is balance: enough structure to manage complexity without creating indirection for its own sake.
