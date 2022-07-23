namespace BudgetApp.API.Dto;

public class BudgetDto
{
    public decimal AvailableToAssign { get; set; } = decimal.Zero;
    public decimal AvailableToSpend { get; set; } = decimal.Zero;

    public List<CategoryDto> Categories { get; set; } = new();
    public List<AccountDto> Accounts { get; set; } = new();
}