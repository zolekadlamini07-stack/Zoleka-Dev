/*
 * Demonstrates: Polymorphism - Override
 * Concept: CreditAccount overrides processWithdrawal to check credit limit
 */

import { Account, TransactionResult } from "./account";

export class CreditAccount extends Account {
    public readonly creditLimit: number;

    constructor(accountNumber: string, accountHolder: string, creditLimit: number) {
        super(accountNumber, accountHolder, 0);
        this.creditLimit = creditLimit;
    }

    override processWithdrawal(amount: number): TransactionResult {
        if (amount <= 0) {
            return TransactionResult.failed("Amount must be greater than zero.");
        }

        const currentDebt = Math.abs(this._balance);
        const availableCredit = this.creditLimit - currentDebt;

        if (amount > availableCredit) {
            return TransactionResult.failed(`Exceeds credit limit. Available credit: R${availableCredit.toFixed(2)}`);
        }

        this._balance -= amount;
        return TransactionResult.succeeded(`Charged R${amount.toFixed(2)}. Outstanding balance: R${Math.abs(this._balance).toFixed(2)}`);
    }

    override getAccountType(): string {
        return "Credit Account";
    }

    get availableCredit(): number {
        return this.creditLimit - Math.abs(this._balance);
    }
}
