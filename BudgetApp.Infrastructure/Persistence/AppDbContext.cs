using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.TransactionAggregate;
using BudgetApp.Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CategoryGroup> CategoryGroups => Set<CategoryGroup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BudgetConfiguration().Configure(modelBuilder.Entity<Budget>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new CategoryGroupConfiguration().Configure(modelBuilder.Entity<CategoryGroup>());
        new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());
    }
}