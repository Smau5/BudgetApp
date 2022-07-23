using BudgetApp.Core.BudgetAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Persistence.Config;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.Property(c => c.AvailableToAssign).HasPrecision(12, 2);
        builder.Navigation(c => c.Categories).AutoInclude();
        builder.Navigation(c => c.Accounts).AutoInclude();
    }
}