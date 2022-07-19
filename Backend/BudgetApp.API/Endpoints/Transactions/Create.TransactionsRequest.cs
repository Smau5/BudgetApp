namespace BudgetApp.API.Endpoints.Transactions;

public class CreateTransactionsRequest
{
    public decimal Amount { get; set; }
    public int? CategoryId { get; set; }
}