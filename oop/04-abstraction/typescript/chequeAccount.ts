/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: ChequeAccount implements all abstract methods from Account
 */

import { Account } from "./account";

export class ChequeAccount extends Account {
    public readonly overdraftLimit: number;
    private _transactionCount: number = 0;
    private static readonly FEE_PER_TRANSACTION = 2.50;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, overdraftLimit: number) {
        super(accountNumber, accountHolder, openingBalance);
        this.overdraftLimit = overdraftLimit;
    }

    get transactionCount(): number {
        return this._transactionCount;
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Withdrawal amount must be greater than zero.");
        }

        const availableFunds = this._balance + this.overdraftLimit;

        if (amount > availableFunds) {
            throw new Error(`Exceeds overdraft limit. Available: R${availableFunds.toFixed(2)}`);
        }

        this._balance -= amount;
        this._transactionCount++;
    }

    calculateMonthlyFees(): number {
        return this._transactionCount * ChequeAccount.FEE_PER_TRANSACTION;
    }

    getAccountSummary(): string {
        return `Cheque Account ${this.accountNumber} | Holder: ${this.accountHolder} | Balance: R${this._balance.toFixed(2)} | Overdraft: R${this.overdraftLimit.toFixed(2)} | Transactions: ${this._transactionCount}`;
    }

    resetTransactionCount(): void {
        this._transactionCount = 0;
    }
}
