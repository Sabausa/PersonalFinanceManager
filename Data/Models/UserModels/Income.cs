namespace Data.Models.UserModels;

public class Income
{
    public int Id { get; set; }
    public IncomeMonth CurrentIncomeMonth { get; set; } = null!;
    public List<IncomeMonth> History { get; set; } = null!;
}