/*
 * Demonstrates: Polymorphism - Base Class
 * Concept: Virtual methods that derived classes override to provide different behaviour
 */

export class TransactionResult {
    private constructor(
        public readonly success: boolean,
        public readonly message: string
    ) {}

    static succeeded(message: string): TransactionResult {
        return new TransactionResult(true, message);
    }

    static failed(message: string): TransactionResult {
        return new TransactionResult(false, message);
    }
}

export class Account {
    public readonly accountNumber: string;
    public readonly accountHolder: string;
    protected _balance: number;

    constructor(accountNumber: string, accountHolder: string, openingBalance: number) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this._balance = openingBalance;
    }

    get balance(): number {
        return this._balance;
    }

    processWithdrawal(amount: number): TransactionResult {
        if (amount <= 0) {
            return TransactionResult.failed("Amount must be greater than zero.");
        }

        if (amount > this._balance) {
            return TransactionResult.failed(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
        }

        this._balance -= amount;
        return TransactionResult.succeeded(`Withdrew R${amount.toFixed(2)}. New balance: R${this._balance.toFixed(2)}`);
    }

    getAccountType(): string {
        return "Standard Account";
    }
}
