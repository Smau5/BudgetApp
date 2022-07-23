using BudgetApp.Core.Shared;
using BudgetApp.Core.TransactionAggregate;

namespace BudgetApp.Core.BudgetAggregate;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }
    public decimal Assigned { get; set; }
    public decimal AvailableToSpend { get; set; }
    public decimal Activity { get; set; } = decimal.Zero;
    public Guid BudgetId { get; set; }

    public Category(string name, decimal assigned)
    {
        Name = name;
        Assigned = assigned;
        AvailableToSpend = assigned;
    }
}