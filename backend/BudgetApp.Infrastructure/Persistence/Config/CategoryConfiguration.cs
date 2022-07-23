using BudgetApp.Core.BudgetAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Assigned).HasPrecision(12, 2);
        builder.Property(c => c.AvailableToSpend).HasPrecision(12, 2);
    }
}