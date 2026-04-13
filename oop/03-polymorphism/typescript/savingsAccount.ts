/*
 * Demonstrates: Polymorphism - Override
 * Concept: SavingsAccount overrides processWithdrawal to enforce minimum balance
 */

import { Account, TransactionResult } from "./account";

export class SavingsAccount extends Account {
    public readonly minimumBalance: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number, minimumBalance: number) {
        super(accountNumber, accountHolder, openingBalance);
        this.minimumBalance = minimumBalance;
    }

    override processWithdrawal(amount: number): TransactionResult {
        if (amount <= 0) {
            return TransactionResult.failed("Amount must be greater than zero.");
        }

        const resultingBalance = this._balance - amount;

        if (resultingBalance < this.minimumBalance) {
            return TransactionResult.failed(`Cannot withdraw. Minimum balance of R${this.minimumBalance.toFixed(2)} required.`);
        }

        this._balance = resultingBalance;
        return TransactionResult.succeeded(`Withdrew R${amount.toFixed(2)}. New balance: R${this._balance.toFixed(2)}`);
    }

    override getAccountType(): string {
        return "Savings Account";
    }
}
