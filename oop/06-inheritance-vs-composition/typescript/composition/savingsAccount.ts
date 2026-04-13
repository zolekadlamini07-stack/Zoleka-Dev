/*
 * Demonstrates: Inheritance vs Composition - Composition Approach
 * Concept: SavingsAccount uses an injected IInterestCalculator instead of inheriting interest behaviour
 */

import { IInterestCalculator } from "./interestCalculator";

export class SavingsAccount {
    private _balance: number;
    private readonly interestCalculator: IInterestCalculator;

    public readonly accountNumber: string;
    public readonly accountHolder: string;
    public readonly minimumBalance: number;

    constructor(
        accountNumber: string,
        accountHolder: string,
        openingBalance: number,
        minimumBalance: number,
        interestCalculator: IInterestCalculator
    ) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
        this.minimumBalance = minimumBalance;
        this.interestCalculator = interestCalculator;
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

        const resultingBalance = this._balance - amount;

        if (resultingBalance < this.minimumBalance) {
            throw new Error(`Cannot withdraw. Minimum balance of R${this.minimumBalance.toFixed(2)} required.`);
        }

        this._balance = resultingBalance;
    }

    calculateInterest(): number {
        return this.interestCalculator.calculateInterest(this._balance);
    }

    applyInterest(): void {
        const interest = this.calculateInterest();
        this._balance += interest;
    }
}
