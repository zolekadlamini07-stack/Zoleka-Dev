/*
 * Demonstrates: Polymorphism - Polymorphic Behaviour
 * Concept: Processor works with any Account type without knowing the specific implementation
 */

import { Account, TransactionResult } from "./account";

export class TransactionProcessor {
    processBatchWithdrawals(accounts: Account[], amount: number): string[] {
        const results: string[] = [];

        for (const account of accounts) {
            const result = account.processWithdrawal(amount);
            const status = result.success ? "SUCCESS" : "FAILED";
            results.push(`[${account.getAccountType()}] ${account.accountNumber}: ${status} - ${result.message}`);
        }

        return results;
    }

    withdrawFromAccount(account: Account, amount: number): TransactionResult {
        return account.processWithdrawal(amount);
    }
}
