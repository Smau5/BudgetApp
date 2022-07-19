using BudgetApp.Core.BudgetAggregate;

namespace BudgetApp.Core.Interfaces;

public interface IBudgetRepository : IBaseRepository<Budget>
{
    Task<Budget?> GetFirstOrDefaultAsync(CancellationToken cancellationToken);
}