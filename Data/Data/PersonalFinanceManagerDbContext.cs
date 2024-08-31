using Data.Models;
using Data.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public class PersonalFinanceManagerDbContext(DbContextOptions<PersonalFinanceManagerDbContext> options)
    : DbContext(options)
{
    
    public DbSet<User> Users { get; set; } = null!;
}