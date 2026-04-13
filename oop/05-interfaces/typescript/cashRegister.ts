/*
 * Demonstrates: Interfaces - Single Interface Implementation
 * Concept: CashRegister implements only ITransactable as it does not require audit logging
 */

import { ITransactable } from "./transactable";

export class CashRegister implements ITransactable {
    private _balance: number;

    public readonly registerId: string;

    constructor(registerId: string, openingFloat: number) {
        this.registerId = registerId;
        this._balance = openingFloat;
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
        if (amount > this._balance) {
            throw new Error(`Insufficient cash in register. Available: R${this._balance.toFixed(2)}`);
        }
        this._balance -= amount;
    }

    closeRegister(): number {
        const finalBalance = this._balance;
        this._balance = 0;
        return finalBalance;
    }
}
