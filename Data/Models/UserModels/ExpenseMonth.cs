﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.UserModels;

public class ExpenseMonth
{
    public int Id { get; set; }
    [MaxLength(15)] public string Name { get; set; } = null!;
    //Uses default currency
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public List<ListItem> ExpenseList { get; set; } = null!;
}