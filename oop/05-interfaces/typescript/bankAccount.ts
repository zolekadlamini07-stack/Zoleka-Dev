/*
 * Demonstrates: Interfaces - Multiple Interface Implementation
 * Concept: BankAccount implements both ITransactable and IAuditable
 */

import { ITransactable } from "./transactable";
import { IAuditable, AuditEntry } from "./auditable";

export class BankAccount implements ITransactable, IAuditable {
    private _balance: number;
    private readonly auditLog: AuditEntry[] = [];

    public readonly accountNumber: string;
    public readonly accountHolder: string;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
        this.recordAudit("ACCOUNT_OPENED", `Opening balance: R${openingBalance.toFixed(2)}`);
    }

    get balance(): number {
        return this._balance;
    }

    deposit(amount: number): void {
        if (amount <= 0) {
            throw new Error("Deposit amount must be greater than zero.");
        }
        this._balance += amount;
        this.recordAudit("DEPOSIT", `Amount: R${amount.toFixed(2)} | New Balance: R${this._balance.toFixed(2)}`);
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Withdrawal amount must be greater than zero.");
        }
        if (amount > this._balance) {
            throw new Error(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
        }
        this._balance -= amount;
        this.recordAudit("WITHDRAWAL", `Amount: R${amount.toFixed(2)} | New Balance: R${this._balance.toFixed(2)}`);
    }

    getAuditLog(): readonly AuditEntry[] {
        return [...this.auditLog];
    }

    recordAudit(action: string, details: string): void {
        this.auditLog.push(new AuditEntry(action, details));
    }
}
