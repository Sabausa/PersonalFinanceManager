using Data.Models.UserModels;

namespace Front.Server.Repository.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> AddUser(User user);
    Task<User?> DeleteUser(int id);
}