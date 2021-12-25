namespace BudgetApp.Core.EFEntities;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;
}