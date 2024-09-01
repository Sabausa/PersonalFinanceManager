using Data.Data;
using Data.Models.UserModels;
using Front.Server.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Front.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository userRepo) : ControllerBase
    {
        [HttpPost(Name = "PostUser")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var u = await userRepo.AddUser(user);
            return Ok(u);
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepo.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromHeader] int id)
        {
            var user = await userRepo.DeleteUser(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
    }
}