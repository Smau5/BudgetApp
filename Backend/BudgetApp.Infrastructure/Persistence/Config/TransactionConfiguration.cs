using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(c => c.Amount).HasPrecision(12, 2);
        builder.HasOne<Budget>().WithMany().HasForeignKey(t => t.BudgetId);
        builder.HasOne<Category>().WithMany().HasForeignKey(t => t.CategoryId);
        builder.HasOne<Account>().WithMany().HasForeignKey(t => t.AccountId);
    }
}