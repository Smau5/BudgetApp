using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Shared;
using BudgetApp.Core.TransactionAggregate;
using BudgetApp.Infrastructure.Persistence.Config;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly IMediator _mediator;

    public AppDbContext(
        DbContextOptions<AppDbContext> options, IMediator mediator
    ) : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Budget> Budgets => Set<Budget>();

    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new BudgetConfiguration().Configure(modelBuilder.Entity<Budget>());
        new AccountConfiguration().Configure(modelBuilder.Entity<Account>());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entitiesWithEvents = ChangeTracker
            .Entries()
            .Select(e => e.Entity as BaseEntity<Guid>)
            .Where(e => e?.Events != null && e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            if (entity is null)
            {
                continue;
            }

            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}