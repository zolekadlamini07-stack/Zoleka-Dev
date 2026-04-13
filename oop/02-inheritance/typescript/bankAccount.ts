/*
 * Demonstrates: Inheritance - Base Class
 * Concept: A base BankAccount class that SavingsAccount and ChequeAccount inherit from
 */

export class BankAccount {
    private readonly transactionHistory: string[] = [];

    public readonly accountNumber: string;
    public readonly accountHolder: string;
    protected _balance: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number) {
        if (!accountNumber?.trim()) {
            throw new Error("Account number is required.");
        }
        if (!accountHolder?.trim()) {
            throw new Error("Account holder name is required.");
        }
        if (openingBalance < 0) {
            throw new Error("Opening balance cannot be negative.");
        }

        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
        this.recordTransaction(`Account opened with R${openingBalance.toFixed(2)}`);
    }

    get balance(): number {
        return this._balance;
    }

    get transactions(): readonly string[] {
        return [...this.transactionHistory];
    }

    deposit(amount: number): void {
        if (amount <= 0) {
            throw new Error("Deposit amount must be greater than zero.");
        }
        this._balance += amount;
        this.recordTransaction(`Deposit: +R${amount.toFixed(2)} | Balance: R${this._balance.toFixed(2)}`);
    }

    withdraw(amount: number): void {
        if (amount <= 0) {
            throw new Error("Withdrawal amount must be greater than zero.");
        }
        if (amount > this._balance) {
            throw new Error(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
        }
        this._balance -= amount;
        this.recordTransaction(`Withdrawal: -R${amount.toFixed(2)} | Balance: R${this._balance.toFixed(2)}`);
    }

    protected recordTransaction(entry: string): void {
        this.transactionHistory.push(entry);
    }

    getStatement(): string {
        return [
            `=== Statement: ${this.accountHolder} (${this.accountNumber}) ===`,
            ...this.transactionHistory,
            `=== Current Balance: R${this._balance.toFixed(2)} ===`
        ].join("\n");
    }
}
