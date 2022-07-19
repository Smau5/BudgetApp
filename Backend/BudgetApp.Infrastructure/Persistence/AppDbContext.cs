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

    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Budget> Budgets => Set<Budget>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new BudgetConfiguration().Configure(modelBuilder.Entity<Budget>());
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}