using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using BudgetApp.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Budgets;

public class Create : EndpointBaseAsync.WithRequest<CreateBudgetsRequest>.WithActionResult<BudgetDto>
{
    private readonly IMapper _mapper;
    private readonly IBudgetRepository _budgetRepository;

    public Create(IMapper mapper, IBudgetRepository budgetRepository)
    {
        _mapper = mapper;
        _budgetRepository = budgetRepository;
    }

    [HttpPost("/Budgets")]
    [SwaggerOperation(
        Summary = "Create budgets",
        Description = "Create budgets",
        OperationId = "Budgets.Create",
        Tags = new[] { "Budgets" })
    ]
    public override async Task<ActionResult<BudgetDto>> HandleAsync(CreateBudgetsRequest request,
        CancellationToken cancellationToken = new())
    {
        var newBudget = new Budget()
        {
            AvailableToAssign = request.AvailableToAssign
        };

        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is not null)
        {
            return BadRequest("Only one budget allowed");
        }

        _budgetRepository.Add(newBudget);
        await _budgetRepository.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<BudgetDto>(newBudget);

        return Ok(response);
    }
}