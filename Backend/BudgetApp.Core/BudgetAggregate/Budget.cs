using BudgetApp.Core.Shared;

namespace BudgetApp.Core.BudgetAggregate;

public class Budget : BaseEntity<Guid>
{
    public decimal AvailableToAssign { get; set; } = decimal.Zero;
    public List<Category> Categories { get; set; } = new();

    public Decimal AvailableToSpend { get; set; } = decimal.Zero;

    public List<Account> Accounts { get; set; } = new();

    public Budget()
    {
    }

    public Category AddCategory(Category category)
    {
        Categories.Add(category);
        AvailableToAssign -= category.Assigned;
        return category;
    }

    public Account AddAccount(Account account)
    {
        Accounts.Add(account);
        AvailableToSpend += account.AvailableToSpend;
        AvailableToAssign += account.AvailableToSpend;
        return account;
    }
}