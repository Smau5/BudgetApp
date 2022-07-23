namespace BudgetApp.API.Endpoints.Accounts;

public class CreateAccountRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal AvailableToSpend { get; set; } = decimal.Zero;
}