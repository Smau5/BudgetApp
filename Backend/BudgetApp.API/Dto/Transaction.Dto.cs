namespace BudgetApp.API.Dto;

public class TransactionDto
{
    public string Id { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public CategoryDto? Category { get; set; }
}