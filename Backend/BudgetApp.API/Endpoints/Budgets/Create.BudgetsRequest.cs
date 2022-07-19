namespace BudgetApp.API.Endpoints.Budgets;

public class CreateBudgetsRequest
{
    public Decimal AvailableToSpend { get; set; } = decimal.Zero;
}