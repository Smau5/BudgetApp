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
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public List(IBudgetRepository budgetRepository, AppDbContext appDbContext, IMapper mapper)
    {
        _budgetRepository = budgetRepository;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpGet("/Categories")]
    [SwaggerOperation(
        Summary = "Create categories",
        Description = "Create categories",
        OperationId = "Categories.Create",
        Tags = new[] { "Categories" })
    ]
    public override async Task<ActionResult<List<CategoryDto>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest();
        }

        var categories = _appDbContext.Categories.Where(c => c.BudgetId == budget.Id).ToList();

        var response = _mapper.Map<List<CategoryDto>>(categories);
        return Ok(response);
    }
}