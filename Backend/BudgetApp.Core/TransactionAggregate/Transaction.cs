using System.ComponentModel.DataAnnotations.Schema;
using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Shared;

namespace BudgetApp.Core.TransactionAggregate;

public class Transaction : BaseEntity<Guid>
{
    public decimal Amount { get; set; } = decimal.Zero;
    public DateTime DateTime { get; set; }
    public int? CategoryId { get; set; }
    public Guid BudgetId { get; set; }
}