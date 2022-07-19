namespace BudgetApp.API.Dto;

public class CategoryDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Assigned { get; set; } = decimal.Zero;
    public decimal AvailableToSpend { get; set; } = decimal.Zero;
    public decimal Activity { get; set; } = decimal.Zero;
}