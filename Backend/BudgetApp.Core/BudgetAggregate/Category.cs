using BudgetApp.Core.Shared;
using BudgetApp.Core.TransactionAggregate;

namespace BudgetApp.Core.BudgetAggregate;

public class Category : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public decimal Assigned { get; set; } = decimal.Zero;
    public decimal AvailableToSpend { get; set; } = decimal.Zero;
    public Guid BudgetId { get; private set; }

    public Category(string name, decimal assigned)
    {
        Name = name;
        Assigned = assigned;
        AvailableToSpend = assigned;
    }
}