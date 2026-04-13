/*
 * Demonstrates: Abstraction - Abstract Class
 * Concept: Abstract class with both implemented and abstract methods that subclasses must override
 */

export abstract class Account {
    public readonly accountNumber: string;
    public readonly accountHolder: string;
    protected _balance: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
    }

    get balance(): number {
        return this._balance;
    }

    deposit(amount: number): void {
        if (amount <= 0) {
            throw new Error("Deposit amount must be greater than zero.");
        }
        this._balance += amount;
    }

    abstract withdraw(amount: number): void;

    abstract calculateMonthlyFees(): number;

    abstract getAccountSummary(): string;

    applyMonthlyFees(): void {
        const fees = this.calculateMonthlyFees();
        if (fees > 0) {
            this._balance -= fees;
        }
    }
}
