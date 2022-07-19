namespace BudgetApp.API.Endpoints.Budgets;

public class CreateBudgetsRequest
{
    public Decimal AvailableToAssign { get; set; } = decimal.Zero;
}