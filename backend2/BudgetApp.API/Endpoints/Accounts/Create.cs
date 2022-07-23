using Ardalis.ApiEndpoints;
using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetApp.API.Endpoints.Accounts;

public class Create : EndpointBaseAsync.WithRequest<CreateAccountRequest>.WithActionResult<AccountDto>
{
    private readonly IMapper _mapper;
    private readonly IBudgetRepository _budgetRepository;

    public Create(IMapper mapper, IBudgetRepository budgetRepository)
    {
        _mapper = mapper;
        _budgetRepository = budgetRepository;
    }

    [HttpPost("/accounts")]
    [SwaggerOperation(
        Summary = "Create account",
        Description = "Create account",
        OperationId = "account.create",
        Tags = new[] { "accounts" })
    ]
    public override async Task<ActionResult<AccountDto>> HandleAsync(CreateAccountRequest request,
        CancellationToken cancellationToken = new())
    {
        var budget = await _budgetRepository.GetFirstOrDefaultAsync(cancellationToken);
        if (budget is null)
        {
            return BadRequest("Budget doesn't exist");
        }

        var newAccount = new Account(request.Name, request.AvailableToSpend);
        budget.AddAccount(newAccount);
        _budgetRepository.Update(budget);
        await _budgetRepository.SaveChangesAsync(cancellationToken);
        var response = _mapper.Map<AccountDto>(newAccount);
        return Ok(response);
    }
}