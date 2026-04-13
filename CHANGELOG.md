# Changelog

All additions are logged here with the date and context.

---

## 2026-03-30 — OOP folder expansion

### Added
- oop/02-inheritance/ — BankAccount base class with SavingsAccount and ChequeAccount subclasses (C# and TypeScript)
- oop/03-polymorphism/ — Multiple account types implementing ProcessWithdrawal differently, with TransactionProcessor (C# and TypeScript)
- oop/04-abstraction/ — Abstract Account class with abstract methods, implemented by SavingsAccount, ChequeAccount, CreditAccount (C# and TypeScript)
- oop/05-interfaces/ — ITransactable and IAuditable interfaces with BankAccount, CashRegister, LoanAgreement implementations (C# and TypeScript)
- oop/06-inheritance-vs-composition/ — Same problem solved two ways: inheritance-based and composition-based interest calculation (C# and TypeScript)
- oop/07-solid-principles/ — All five SOLID principles with violation and refactored examples:
  - 01-single-responsibility/ — Transaction processing separated from formatting and notification
  - 02-open-closed/ — Fee calculator using strategy pattern instead of switch statement
  - 03-liskov-substitution/ — Separate interfaces for withdrawable vs non-withdrawable accounts
  - 04-interface-segregation/ — Large IAccountService split into focused interfaces
  - 05-dependency-inversion/ — TransactionService depending on abstractions for storage and notification

### Changed
- Renamed oop/encapsulation/ to oop/01-encapsulation/ for consistent numbering
- Removed inline usage comments from existing code files (01-encapsulation C# and TypeScript)
- Updated oop/TOPICS.md to reflect completed implementations

### Context
Comprehensive OOP examples using the finance domain. Each concept folder contains a README explaining the concept, plus C# and TypeScript implementations. SOLID principles include both violation examples and refactored versions to illustrate the difference.

---

## 2026-03-31 — Initial commit

### Added
- Repository structure and root README
- oop/ folder with README and TOPICS tracker
- oop/encapsulation/ — C# and TypeScript examples using a finance domain (BankAccount)
- project-concepts/module-federation/ — working three-app demo: portal shell, finance remote, hr remote
- Placeholder README files for clean-architecture/, cloud-native/, tdd-and-katas/, react-typescript/

### Context
Initial scaffold. OOP starts with encapsulation as the logical foundation using a finance domain. Module federation demo covers host/remote configuration, runtime loading, shared dependencies, role-based access, and auth flow from shell to remotes.
