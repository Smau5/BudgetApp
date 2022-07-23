using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Accounts.Transactions;

public class List : EndpointBaseAsync.WithRequest<int>.WithActionResult<List<TransactionDto>>
{
    private readonly IMapper _mapper;
    private readonly IBudgetRepository _budgetRepository;
    private readonly AppDbContext _appDbContext;

    public List(IMapper mapper, IBudgetRepository budgetRepository, AppDbContext appDbContext)
    {
        _mapper = mapper;
        _budgetRepository = budgetRepository;
        _appDbContext = appDbContext;
    }

    [HttpGet("/accounts/{accountId}/transactions")]
    [SwaggerOperation(
        Summary = "List transactions",
        Description = "List transactions",
        OperationId = "transactions.list",
        Tags = new[] { "transactions" })
    ]
    public override async Task<ActionResult<List<TransactionDto>>> HandleAsync([FromRoute] int accountId,
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("budget doesn't exist.");
        }

        var transactions = _appDbContext.Transactions.Where(t => t.BudgetId == budget.Id && t.AccountId == accountId)
            .OrderBy(t => t.DateTime).ToList();

        var response = _mapper.Map<List<TransactionDto>>(transactions);

        return Ok(response);
    }
}