using System.ComponentModel.DataAnnotations;

namespace Data.Models.UserModels;

public class User
{
    public int Id { get; set; }
    [MaxLength(15)]
    public string FirstName { get; set; } = null!;
    [MaxLength(15)]
    public string LastName { get; set; } = null!;
    public Settings Settings { get; set; } = null!;
    public Expenditure Expenditure { get; set; } = null!;
    public Income Income { get; set; } = null!;
    
}