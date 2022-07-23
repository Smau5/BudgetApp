using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Persistence.Repositories;

public class BudgetRepository : BaseRepository<Budget>, IBudgetRepository
{
    private readonly AppDbContext _appDbContext;

    public BudgetRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Budget?> GetFirstOrDefaultAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext.Budgets.FirstOrDefaultAsync(cancellationToken);
    }
}