using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using BudgetApp.Core.TransactionAggregate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Transactions;

public class Create : EndpointBaseAsync.WithRequest<CreateTransactionsRequest>.WithActionResult<TransactionDto>
{
    private readonly IMapper _mapper;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IBudgetRepository _budgetRepository;

    public Create(IMapper mapper, ITransactionRepository transactionRepository, IBudgetRepository budgetRepository)
    {
        _mapper = mapper;
        _transactionRepository = transactionRepository;
        _budgetRepository = budgetRepository;
    }

    [HttpPost("/transactions")]
    [SwaggerOperation(
        Summary = "Create transactions",
        Description = "Create transactions",
        OperationId = "transactions.create",
        Tags = new[] { "transactions" })
    ]
    public override async Task<ActionResult<TransactionDto>> HandleAsync(CreateTransactionsRequest request,
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("budget doesn't exist.");
        }

        var newTransaction =
            new Transaction(request.Amount, DateTime.UtcNow, budget.Id, request.AccountId, request.CategoryId);

        _transactionRepository.Add(newTransaction);
        await _transactionRepository.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<TransactionDto>(newTransaction);
        return Ok(response);
    }
}