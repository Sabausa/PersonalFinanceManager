using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.UserModels;

public class ListItem
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    [MaxLength(5)]
    public string Currency { get; set; } = null!;
    [MaxLength(20)]
    public string Type { get; set; } = null!;
}