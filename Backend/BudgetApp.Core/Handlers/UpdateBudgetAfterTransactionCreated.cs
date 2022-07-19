using BudgetApp.Core.Events;
using BudgetApp.Core.Interfaces;
using MediatR;

namespace BudgetApp.Core.Handlers;

public class UpdateBudgetAfterTransactionCreated : INotificationHandler<TransactionCreatedEvent>
{
    private readonly IBudgetRepository _budgetRepository;

    public UpdateBudgetAfterTransactionCreated(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task Handle(TransactionCreatedEvent transactionCreatedEvent, CancellationToken cancellationToken)
    {
        var createdTransaction = transactionCreatedEvent.TransactionCreated;
        var budget = await _budgetRepository.GetByIdAsync(createdTransaction.BudgetId, cancellationToken);

        if (budget is null)
        {
            throw new ArgumentException("Budget doesn't exist");
        }

        if (createdTransaction.CategoryId is null)
        {
            budget.AvailableToAssign += createdTransaction.Amount;
        }
        else
        {
            var category = budget.Categories.FirstOrDefault(c => c.Id == createdTransaction.CategoryId);

            if (category is null)
            {
                throw new ArgumentException("Category doesn't exist");
            }

            category.AvailableToSpend += createdTransaction.Amount;
            category.Activity += createdTransaction.Amount;
        }

        budget.AvailableToSpend += createdTransaction.Amount;
        _budgetRepository.Update(budget);
    }
}