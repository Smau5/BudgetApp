namespace BudgetApp.Core.Interfaces;

public interface IBaseRepository<T>
{
    T Add(T entity);
    T Update(T entity);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}