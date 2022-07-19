using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Budgets;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<BudgetDto>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly IMapper _mapper;

    public Get(IBudgetRepository budgetRepository, IMapper mapper)
    {
        _budgetRepository = budgetRepository;
        _mapper = mapper;
    }

    [HttpGet("/Budgets")]
    [SwaggerOperation(
        Summary = "Get budget",
        Description = "Get budget",
        OperationId = "Budgets.Get",
        Tags = new[] { "Budgets" })
    ]
    public override async Task<ActionResult<BudgetDto>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("budget doesn't exist");
        }

        var response = _mapper.Map<BudgetDto>(budget);

        return Ok(response);
    }
}