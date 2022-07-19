namespace BudgetApp.API.Endpoints.Categories;

public class CreateCategoriesRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Assigned { get; set; } = Decimal.Zero;
}