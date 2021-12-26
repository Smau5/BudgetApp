using BudgetApp.Core.EFEntities;

namespace BudgetApp.Core.BudgetAggregate;

public class CategoryGroup : BaseEntity<Guid>
{
    private readonly List<Category> _categories = new List<Category>();
    public IEnumerable<Category> Categories => _categories.AsReadOnly();

    public Category AddNewCategory(Category category)
    {
        _categories.Add(category);
        return category;
    }
}