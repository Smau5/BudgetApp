using BudgetApp.Core.BudgetAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.Property(b => b.AvailableAmount).HasPrecision(ColumnConstants.PRECISION, ColumnConstants.SCALE);
        builder.Property(p => p.Id).ValueGeneratedNever();
    }
}