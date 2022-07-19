using BudgetApp.Core.Interfaces;
using BudgetApp.Core.TransactionAggregate;

namespace BudgetApp.Infrastructure.Persistence.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}