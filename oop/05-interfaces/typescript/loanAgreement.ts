/*
 * Demonstrates: Interfaces - Single Interface Implementation
 * Concept: LoanAgreement implements only IAuditable as it tracks changes but is not directly transactable
 */

import { IAuditable, AuditEntry } from "./auditable";

export enum LoanStatus {
    Pending = "Pending",
    Approved = "Approved",
    Active = "Active",
    Closed = "Closed"
}

export class LoanAgreement implements IAuditable {
    private readonly auditLog: AuditEntry[] = [];
    private _status: LoanStatus;

    public readonly agreementNumber: string;
    public readonly borrowerName: string;
    public readonly principalAmount: number;
    public readonly interestRate: number;

    constructor(agreementNumber: string, borrowerName: string, principalAmount: number, interestRate: number) {
        this.agreementNumber = agreementNumber;
        this.borrowerName = borrowerName;
        this.principalAmount = principalAmount;
        this.interestRate = interestRate;
        this._status = LoanStatus.Pending;
        this.recordAudit("LOAN_CREATED", `Principal: R${principalAmount.toFixed(2)} | Rate: ${(interestRate * 100).toFixed(2)}%`);
    }

    get status(): LoanStatus {
        return this._status;
    }

    approve(): void {
        if (this._status !== LoanStatus.Pending) {
            throw new Error("Only pending loans can be approved.");
        }
        this._status = LoanStatus.Approved;
        this.recordAudit("LOAN_APPROVED", `Agreement ${this.agreementNumber} approved`);
    }

    disburse(): void {
        if (this._status !== LoanStatus.Approved) {
            throw new Error("Only approved loans can be disbursed.");
        }
        this._status = LoanStatus.Active;
        this.recordAudit("LOAN_DISBURSED", `Principal R${this.principalAmount.toFixed(2)} disbursed to ${this.borrowerName}`);
    }

    close(): void {
        if (this._status !== LoanStatus.Active) {
            throw new Error("Only active loans can be closed.");
        }
        this._status = LoanStatus.Closed;
        this.recordAudit("LOAN_CLOSED", `Agreement ${this.agreementNumber} closed`);
    }

    getAuditLog(): readonly AuditEntry[] {
        return [...this.auditLog];
    }

    recordAudit(action: string, details: string): void {
        this.auditLog.push(new AuditEntry(action, details));
    }
}
