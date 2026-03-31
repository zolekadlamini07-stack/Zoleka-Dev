class BankAccount {
  private _balance: number;
  private readonly _transactionHistory: string[] = [];

  public readonly accountNumber: string;
  public readonly accountHolder: string;

  private constructor(accountNumber: string, accountHolder: string, openingBalance: number) {
    this.accountNumber = accountNumber;
    this.accountHolder = accountHolder;
    this._balance = openingBalance;
    this._transactionHistory.push(`Account opened with R${openingBalance.toFixed(2)}`);
  }

  static create(accountNumber: string, accountHolder: string, openingBalance: number): BankAccount {
    if (!accountNumber?.trim()) throw new Error("Account number is required.");
    if (!accountHolder?.trim()) throw new Error("Account holder name is required.");
    if (openingBalance < 0) throw new Error("Opening balance cannot be negative.");
    return new BankAccount(accountNumber, accountHolder, openingBalance);
  }

  get balance(): number {
    return this._balance;
  }

  get transactionHistory(): readonly string[] {
    return [...this._transactionHistory];
  }

  deposit(amount: number): void {
    if (amount <= 0) throw new Error("Deposit amount must be greater than zero.");
    this._balance += amount;
    this._transactionHistory.push(`Deposit: +R${amount.toFixed(2)} | Balance: R${this._balance.toFixed(2)}`);
  }

  withdraw(amount: number): void {
    if (amount <= 0) throw new Error("Withdrawal amount must be greater than zero.");
    if (amount > this._balance) throw new Error(`Insufficient funds. Available: R${this._balance.toFixed(2)}`);
    this._balance -= amount;
    this._transactionHistory.push(`Withdrawal: -R${amount.toFixed(2)} | Balance: R${this._balance.toFixed(2)}`);
  }

  getStatement(): string {
    return [
      `=== Statement: ${this.accountHolder} (${this.accountNumber}) ===`,
      ...this._transactionHistory,
      `=== Current Balance: R${this._balance.toFixed(2)} ===`
    ].join("\n");
  }
}

export { BankAccount };

// Usage:
// const account = BankAccount.create("ACC-001", "Account Holder Name", 1000);
// account.deposit(500);
// account.withdraw(200);
// console.log(account.getStatement());
