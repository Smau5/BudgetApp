using BudgetApp.Core.Events;
using BudgetApp.Core.Shared;

namespace BudgetApp.Core.TransactionAggregate;

public class Transaction : BaseEntity<Guid>
{
    public decimal Amount { get; set; } = decimal.Zero;
    public DateTime DateTime { get; set; }
    public int? CategoryId { get; set; }
    public Guid BudgetId { get; set; }


    public Transaction(decimal amount, DateTime dateTime, Guid budgetId, int? categoryId)
    {
        Amount = amount;
        DateTime = dateTime;
        CategoryId = categoryId;
        BudgetId = budgetId;

        Events.Add(new TransactionCreatedEvent(this));
    }
}