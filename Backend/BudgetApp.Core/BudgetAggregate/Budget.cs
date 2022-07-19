using BudgetApp.Core.Shared;

namespace BudgetApp.Core.BudgetAggregate;

public class Budget : BaseEntity<Guid>
{
    public Decimal AvailableToAssign { get; set; } = decimal.Zero;
    public List<Category> Categories { get; set; } = new();

    public Decimal AvailableToSpend { get; set; } = decimal.Zero;

    public Budget(Decimal availableToSpend)
    {
        AvailableToSpend = availableToSpend;
        AvailableToAssign = availableToSpend;
    }

    public Category AddCategory(Category category)
    {
        Categories.Add(category);
        AvailableToAssign -= category.Assigned;
        return category;
    }
}