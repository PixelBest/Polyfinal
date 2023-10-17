using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet("Me")]
        [Authorize]
        public async Task<ActionResult<User>> Me()
        {
            var user = await db.User.FirstOrDefaultAsync();
            return Ok(user);
        }
        
        [HttpPost("Signin")]
        public async Task<ActionResult<int>> Signin(User user)
        {
            var u = await db.User.FirstOrDefaultAsync(x => x == user);
            return Ok(u.Id);
        }
        
        [HttpPost("SignUp")]
        public async Task SignUp(User user)
        {
            db.User.Add(user);
            await db.SaveChangesAsync();
        }

        [HttpPost("SignOut")]
        [Authorize]
        public async Task<ActionResult<User>> SignOut()
        {
            User user = new User();
            return Ok(user);
        }

        [HttpPost("Update")]
        [Authorize]
        public async Task Update(User user)
        {
            if(db.User.FirstOrDefault(x => x.Username == user.Username) == null)
            {
                db.User.Update(user);
                await db.SaveChangesAsync();
            }
        }

    }
}
