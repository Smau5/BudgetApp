using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Accounts;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<AccountDto>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly IMapper _mapper;

    public Get(IBudgetRepository budgetRepository, IMapper mapper)
    {
        _budgetRepository = budgetRepository;
        _mapper = mapper;
    }

    [HttpGet("/accounts/{id}")]
    [SwaggerOperation(
        Summary = "Get account",
        Description = "Get account",
        OperationId = "accounts.get",
        Tags = new[] { "accounts" })
    ]
    public override async Task<ActionResult<AccountDto>> HandleAsync([FromRoute] int id,
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("budget doesn't exist.");
        }

        var account = budget.Accounts.FirstOrDefault(b => b.Id == id);
        if (account is null)
        {
            return BadRequest("account doesn't exist.");
        }

        var response = _mapper.Map<AccountDto>(account);

        return Ok(response);
    }
}