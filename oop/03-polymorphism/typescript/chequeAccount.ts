/*
 * Demonstrates: Polymorphism - Override
 * Concept: ChequeAccount overrides processWithdrawal to allow overdraft
 */

import { Account, TransactionResult } from "./account";

export class ChequeAccount extends Account {
    public readonly overdraftLimit: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, overdraftLimit: number) {
        super(accountNumber, accountHolder, openingBalance);
        this.overdraftLimit = overdraftLimit;
    }

    override processWithdrawal(amount: number): TransactionResult {
        if (amount <= 0) {
            return TransactionResult.failed("Amount must be greater than zero.");
        }

        const availableFunds = this._balance + this.overdraftLimit;

        if (amount > availableFunds) {
            return TransactionResult.failed(`Exceeds overdraft limit. Available: R${availableFunds.toFixed(2)}`);
        }

        this._balance -= amount;
        return TransactionResult.succeeded(`Withdrew R${amount.toFixed(2)}. New balance: R${this._balance.toFixed(2)}`);
    }

    override getAccountType(): string {
        return "Cheque Account";
    }
}
