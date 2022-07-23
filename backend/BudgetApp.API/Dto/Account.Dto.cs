namespace BudgetApp.API.Dto;

public class AccountDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal AvailableToSpend { get; set; }
}