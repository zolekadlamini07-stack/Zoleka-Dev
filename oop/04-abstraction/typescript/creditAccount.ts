/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: CreditAccount implements all abstract methods from Account
 */

import { Account } from "./account";

export class CreditAccount extends Account {
    public readonly creditLimit: number;
    public readonly interestRate: number;

    constructor(accountNumber: string, accountHolder: string, creditLimit: number, interestRate: number) {
        super(accountNumber, accountHolder, 0);
        this.creditLimit = creditLimit;
        this.interestRate = interestRate;
    }

    get outstandingBalance(): number {
        return Math.abs(Math.min(this._balance, 0));
    }

    get availableCredit(): number {
        return this.creditLimit - this.outstandingBalance;
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Amount must be greater than zero.");
        }
        if (amount > this.availableCredit) {
            throw new Error(`Exceeds credit limit. Available: R${this.availableCredit.toFixed(2)}`);
        }
        this._balance -= amount;
    }

    calculateMonthlyFees(): number {
        return this.outstandingBalance * this.interestRate;
    }

    getAccountSummary(): string {
        return `Credit Account ${this.accountNumber} | Holder: ${this.accountHolder} | Outstanding: R${this.outstandingBalance.toFixed(2)} | Available Credit: R${this.availableCredit.toFixed(2)}`;
    }

    makePayment(amount: number): void {
        if (amount <= 0) {
            throw new Error("Payment amount must be greater than zero.");
        }
        this._balance += amount;
    }
}
