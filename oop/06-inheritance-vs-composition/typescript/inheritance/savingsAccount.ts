/*
 * Demonstrates: Inheritance vs Composition - Inheritance Approach
 * Concept: SavingsAccount inherits interest behaviour from InterestBearingAccount
 */

import { InterestBearingAccount } from "./interestBearingAccount";

export class SavingsAccount extends InterestBearingAccount {
    public readonly minimumBalance: number;

    constructor(
        accountNumber: string,
        accountHolder: string,
        openingBalance: number,
        interestRate: number,
        minimumBalance: number
    ) {
        super(accountNumber, accountHolder, openingBalance, interestRate);
        this.minimumBalance = minimumBalance;
    }

    override withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Amount must be greater than zero.");
        }

        const resultingBalance = this._balance - amount;

        if (resultingBalance < this.minimumBalance) {
            throw new Error(`Cannot withdraw. Minimum balance of R${this.minimumBalance.toFixed(2)} required.`);
        }

        this._balance = resultingBalance;
    }
}
