using BudgetApp.Core.EFEntities;

namespace BudgetApp.Core.BudgetAggregate;

public class Budget : BaseEntity<Guid>
{
    private readonly List<CategoryGroup> _categories = new List<CategoryGroup>();
    public IEnumerable<CategoryGroup> Categories => _categories.AsReadOnly();
    public decimal AvailableAmount { get; private set; }
    public string Name { get; set; } = string.Empty;

    public CategoryGroup AddNewCategoryGroup(CategoryGroup category)
    {
        _categories.Add(category);
        return category;
    }
}