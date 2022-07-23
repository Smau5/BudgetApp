using BudgetApp.Core.Interfaces;
using BudgetApp.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<Guid>
{
    private readonly AppDbContext _appDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public virtual T Add(T entity)
    {
        _appDbContext.Set<T>().Add(entity);
        return entity;
    }

    public virtual T Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        return entity;
    }

    public virtual Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        return entity;
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}