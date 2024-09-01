using Data.Data;
using Data.Models.UserModels;
using Front.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Front.Server.Repository.Services;

public class UserRepository(PersonalFinanceManagerDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers()  =>   await context.Users.ToListAsync(); 

    public async Task<User> AddUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> DeleteUser(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return null;
        }
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return user;

    }
}