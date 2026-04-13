/*
 * Demonstrates: Interfaces - Contract Definition
 * Concept: ITransactable defines the contract for any class that handles money flow
 */

export interface ITransactable {
    readonly balance: number;
    deposit(amount: number): void;
    withdraw(amount: number): void;
}
