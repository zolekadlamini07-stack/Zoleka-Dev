/*
 * Demonstrates: Dependency Inversion Principle - Refactored
 * Concept: High-level TransactionService depends on abstractions, not concretions
 */

namespace FinanceDomain.SOLID.DIP.Refactored;

public class TransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly INotificationService _notificationService;

    public TransactionService(ITransactionRepository repository, INotificationService notificationService)
    {
        _repository = repository;
        _notificationService = notificationService;
    }

    public void ProcessTransaction(string accountNumber, decimal amount, string type, string notificationRecipient)
    {
        var transaction = new Transaction(accountNumber, amount, type);

        _repository.Save(transaction);

        _notificationService.SendNotification(
            notificationRecipient,
            $"Transaction {transaction.Id} processed: {type} of R{amount:F2}"
        );
    }

    public IEnumerable<Transaction> GetAccountTransactions(string accountNumber)
    {
        return _repository.GetByAccount(accountNumber);
    }

    public Transaction? GetTransaction(string transactionId)
    {
        return _repository.GetById(transactionId);
    }
}
