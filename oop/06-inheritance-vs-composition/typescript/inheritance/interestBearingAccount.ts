/*
 * Demonstrates: Inheritance vs Composition - Inheritance Approach
 * Concept: Base class that provides interest calculation behaviour through inheritance
 */

export abstract class InterestBearingAccount {
    public readonly accountNumber: string;
    public readonly accountHolder: string;
    protected _balance: number;
    public readonly interestRate: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, interestRate: number) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
        this.interestRate = interestRate;
    }

    get balance(): number {
        return this._balance;
    }

    deposit(amount: number): void {
        if (amount <= 0) {
            throw new Error("Amount must be greater than zero.");
        }
        this._balance += amount;
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Amount must be greater than zero.");
        }
        if (amount > this._balance) {
            throw new Error(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
        }
        this._balance -= amount;
    }

    calculateInterest(): number {
        return this._balance * this.interestRate;
    }

    applyInterest(): void {
        const interest = this.calculateInterest();
        this._balance += interest;
    }
}
