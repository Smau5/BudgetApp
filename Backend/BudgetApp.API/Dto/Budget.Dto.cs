namespace BudgetApp.API.Dto;

public class BudgetDto
{
    public Decimal AvailableToAssign { get; set; } = decimal.Zero;

    public List<CategoryDto> Categories { get; set; } = new();
}