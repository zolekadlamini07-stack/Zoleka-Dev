/*
 * Demonstrates: Abstraction - Concrete Implementation
 * Concept: SavingsAccount implements all abstract methods from Account
 */

import { Account } from "./account";

export class SavingsAccount extends Account {
    public readonly interestRate: number;
    private static readonly MONTHLY_FEE = 0;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, interestRate: number) {
        super(accountNumber, accountHolder, openingBalance);
        this.interestRate = interestRate;
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Withdrawal amount must be greater than zero.");
        }
        if (amount > this._balance) {
            throw new Error(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
        }
        this._balance -= amount;
    }

    calculateMonthlyFees(): number {
        return SavingsAccount.MONTHLY_FEE;
    }

    getAccountSummary(): string {
        return `Savings Account ${this.accountNumber} | Holder: ${this.accountHolder} | Balance: R${this._balance.toFixed(2)} | Interest Rate: ${(this.interestRate * 100).toFixed(2)}%`;
    }

    applyInterest(): void {
        const interest = this._balance * this.interestRate;
        this._balance += interest;
    }
}
