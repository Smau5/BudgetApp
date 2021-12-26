using BudgetApp.Core.BudgetAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(b => b.AvailableAmount).HasPrecision(ColumnConstants.PRECISION, ColumnConstants.SCALE);
        builder.Property(b => b.AssignedAmount).HasPrecision(ColumnConstants.PRECISION, ColumnConstants.SCALE);
        builder.Property(p => p.Id).ValueGeneratedNever();
    }
}