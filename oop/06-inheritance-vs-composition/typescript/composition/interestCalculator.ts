/*
 * Demonstrates: Inheritance vs Composition - Composition Approach
 * Concept: Standalone InterestCalculator that can be injected into any account
 */

export interface IInterestCalculator {
    calculateInterest(balance: number): number;
}

export class SimpleInterestCalculator implements IInterestCalculator {
    public readonly rate: number;

    constructor(rate: number) {
        if (rate < 0 || rate > 1) {
            throw new Error("Rate must be between 0 and 1.");
        }
        this.rate = rate;
    }

    calculateInterest(balance: number): number {
        return balance * this.rate;
    }
}

export class TieredInterestCalculator implements IInterestCalculator {
    private readonly lowTierRate: number;
    private readonly highTierRate: number;
    private readonly threshold: number;

    constructor(lowTierRate: number, highTierRate: number, threshold: number) {
        this.lowTierRate = lowTierRate;
        this.highTierRate = highTierRate;
        this.threshold = threshold;
    }

    calculateInterest(balance: number): number {
        if (balance <= this.threshold) {
            return balance * this.lowTierRate;
        }

        const lowTierInterest = this.threshold * this.lowTierRate;
        const highTierInterest = (balance - this.threshold) * this.highTierRate;

        return lowTierInterest + highTierInterest;
    }
}
