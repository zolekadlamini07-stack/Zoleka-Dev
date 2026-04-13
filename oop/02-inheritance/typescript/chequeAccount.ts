/*
 * Demonstrates: Inheritance - Derived Class with Override
 * Concept: ChequeAccount inherits from BankAccount and overrides withdraw to allow overdraft
 */

import { BankAccount } from "./bankAccount";

export class ChequeAccount extends BankAccount {
    public readonly overdraftLimit: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, overdraftLimit: number) {
        super(accountNumber, accountHolder, openingBalance);

        if (overdraftLimit < 0) {
            throw new Error("Overdraft limit cannot be negative.");
        }

        this.overdraftLimit = overdraftLimit;
    }

    override withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Withdrawal amount must be greater than zero.");
        }

        const availableFunds = this._balance + this.overdraftLimit;

        if (amount > availableFunds) {
            throw new Error(`Exceeds overdraft limit. Available: R${availableFunds.toFixed(2)}`);
        }

        this._balance -= amount;
        this.recordTransaction(`Withdrawal: -R${amount.toFixed(2)} | Balance: R${this._balance.toFixed(2)}`);
    }

    get availableFunds(): number {
        return this._balance + this.overdraftLimit;
    }
}
