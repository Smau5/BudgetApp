using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.API.Endpoints.Accounts.Transactions;

public class CreateTransactionsRequest
{
    [FromRoute(Name = "accountId")] public int AccountId { get; set; }
    [FromBody] public CreateTransactionsRequestBody CreateTransactionsRequestBody { get; set; } = new();
}

public class CreateTransactionsRequestBody
{
    public decimal Amount { get; set; }
    public int? CategoryId { get; set; }

    public DateTime Date { get; set; }
}