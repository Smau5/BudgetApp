using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.API.Endpoints;

public class Test : EndpointBaseAsync.WithoutRequest.WithoutResult
{
    [AllowAnonymous]
    [HttpGet("/test")]
    public override Task<ActionResult> HandleAsync(CancellationToken cancellationToken = new())
    {
        return Task.FromResult<ActionResult>(Ok("Working!"));
    }
}