/*
 * Demonstrates: Inheritance - Derived Class
 * Concept: SavingsAccount inherits from BankAccount and adds interest calculation
 */

import { BankAccount } from "./bankAccount";

export class SavingsAccount extends BankAccount {
    public readonly interestRate: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, interestRate: number) {
        super(accountNumber, accountHolder, openingBalance);

        if (interestRate < 0 || interestRate > 1) {
            throw new Error("Interest rate must be between 0 and 1.");
        }

        this.interestRate = interestRate;
    }

    applyInterest(): void {
        const interest = this._balance * this.interestRate;
        this._balance += interest;
        this.recordTransaction(
            `Interest applied: +R${interest.toFixed(2)} at ${(this.interestRate * 100).toFixed(2)}% | Balance: R${this._balance.toFixed(2)}`
        );
    }

    calculateInterest(): number {
        return this._balance * this.interestRate;
    }
}
