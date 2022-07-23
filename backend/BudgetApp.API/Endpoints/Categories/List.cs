using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Categories;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<List<CategoryDto>>
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly IMapper _mapper;

    public List(IBudgetRepository budgetRepository, IMapper mapper)
    {
        _budgetRepository = budgetRepository;
        _mapper = mapper;
    }

    [HttpGet("/categories")]
    [SwaggerOperation(
        Summary = "List categories",
        Description = "List categories",
        OperationId = "categories.list",
        Tags = new[] { "categories" })
    ]
    public override async Task<ActionResult<List<CategoryDto>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest();
        }

        var response = _mapper.Map<List<CategoryDto>>(budget.Categories);
        return Ok(response);
    }
}