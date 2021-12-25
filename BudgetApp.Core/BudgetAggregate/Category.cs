using BudgetApp.Core.EFEntities;

namespace BudgetApp.Core.BudgetAggregate;

public class Category : BaseEntity<Guid>
{
    public decimal AvailableAmount { get; set; }
    public decimal AssignedAmount { get; set; }
}