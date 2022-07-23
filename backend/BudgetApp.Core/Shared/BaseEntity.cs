using MediatR;

namespace BudgetApp.Core.Shared;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;
    public List<INotification> Events = new List<INotification>();
}