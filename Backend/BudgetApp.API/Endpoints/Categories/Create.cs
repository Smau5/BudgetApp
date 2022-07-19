using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Categories;

public class Create : EndpointBaseAsync.WithRequest<CreateCategoriesRequest>.WithActionResult<CategoryDto>
{
    private readonly IMapper _mapper;
    private readonly IBudgetRepository _budgetRepository;

    public Create(IMapper mapper, IBudgetRepository budgetRepository)
    {
        _mapper = mapper;
        _budgetRepository = budgetRepository;
    }

    [HttpPost("/Categories")]
    [SwaggerOperation(
        Summary = "Create category",
        Description = "Create category",
        OperationId = "Category.Create",
        Tags = new[] { "Categories" })
    ]
    public override async Task<ActionResult<CategoryDto>> HandleAsync(CreateCategoriesRequest request,
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("Budget doesn't exist");
        }

        var newCategory = new Category(request.Name, request.Assigned);

        budget.AddCategory(newCategory);
        _budgetRepository.Update(budget);
        await _budgetRepository.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<CategoryDto>(newCategory);

        return Ok(response);
    }
}