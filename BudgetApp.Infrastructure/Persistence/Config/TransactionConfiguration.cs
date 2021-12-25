using BudgetApp.Core.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(b => b.Amount).HasPrecision(ColumnConstants.PRECISION, ColumnConstants.SCALE);
        builder.Property(p => p.Id).ValueGeneratedNever();
    }
}