using BudgetApp.Core.TransactionAggregate;
using MediatR;

namespace BudgetApp.Core.Events;

public class TransactionCreatedEvent : INotification
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Transaction TransactionCreated { get; private set; }

    public TransactionCreatedEvent(Transaction transaction)
    {
        TransactionCreated = transaction;
    }
}