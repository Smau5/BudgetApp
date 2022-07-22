using BudgetApp.Core.Shared;

namespace BudgetApp.Core.BudgetAggregate;

public class Account : BaseEntity<int>
{
    public string Name { get; set; }
    public decimal AvailableToSpend { get; set; } = decimal.Zero;
    public Guid BudgetId { get; set; }
    public Account(string name, decimal availableToSpend)
    {
        Name = name;
        AvailableToSpend = availableToSpend;
    }
}