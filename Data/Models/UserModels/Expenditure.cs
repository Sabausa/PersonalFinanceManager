namespace Data.Models.UserModels;

public class Expenditure
{
    public int Id { get; set; }
    public ExpenseMonth CurrentExpenseMonth { get; set; } = null!;
    public List<ExpenseMonth> History { get; set; } = null!;
}