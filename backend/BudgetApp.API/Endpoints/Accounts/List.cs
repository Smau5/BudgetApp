using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Accounts;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<List<AccountDto>>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly IMapper _mapper;

    public List(IBudgetRepository budgetRepository, IMapper mapper)
    {
        _budgetRepository = budgetRepository;
        _mapper = mapper;
    }

    [HttpGet("/accounts")]
    [SwaggerOperation(
        Summary = "List accounts",
        Description = "List accounts",
        OperationId = "accounts.list",
        Tags = new[] { "accounts" })
    ]
    public override async Task<ActionResult<List<AccountDto>>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null) return BadRequest();

        var response = _mapper.Map<List<AccountDto>>(budget.Accounts);
        return Ok(response);
    }
}