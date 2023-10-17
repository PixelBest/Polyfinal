using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/admin/account")]
    public class AdminAccountController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAdmin()
        {
            var users = await db.User.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAdmin(int id)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }

        [HttpPost]
        public async Task PostAdmin(string username, string password, bool isAdmin, double balance)
        {
            User user = new User()
            {
                Username = username,
                Password = password,
                isAdmin = isAdmin,
                Balance = balance
            };
            db.User.Add(user);
            await db.SaveChangesAsync();
        }
        
        [HttpPut("{id}")]
        public async Task PutAdmin(int id, string username, string password, bool isAdmin, double balance)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Id == id);
            user.Username = username;
            user.Password = password;
            user.Balance = balance;
            user.isAdmin = isAdmin;
            db.User.Update(user);
            await db.SaveChangesAsync();
        }
        
        [HttpDelete("{id}")]
        public async Task DeleteAdmin(int id)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Id == id);
            db.User.Remove(user);
            await db.SaveChangesAsync();
        }
    }
}
