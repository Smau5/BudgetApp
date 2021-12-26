using BudgetApp.Core.EFEntities;

namespace BudgetApp.Core.TransactionAggregate;

public class Transaction : BaseEntity<Guid>
{
    public Guid CategoryId { get; private set; }
    public decimal Amount { get; set; }
}