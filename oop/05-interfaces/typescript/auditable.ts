/*
 * Demonstrates: Interfaces - Contract Definition
 * Concept: IAuditable defines the contract for any class that must track changes for compliance
 */

export class AuditEntry {
    public readonly timestamp: Date;
    public readonly action: string;
    public readonly details: string;

    constructor(action: string, details: string) {
        this.timestamp = new Date();
        this.action = action;
        this.details = details;
    }

    toString(): string {
        const formatted = this.timestamp.toISOString().replace("T", " ").substring(0, 19);
        return `[${formatted}] ${this.action}: ${this.details}`;
    }
}

export interface IAuditable {
    getAuditLog(): readonly AuditEntry[];
    recordAudit(action: string, details: string): void;
}
