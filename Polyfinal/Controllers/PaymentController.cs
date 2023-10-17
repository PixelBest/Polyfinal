using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpPost("Hesoyam/{accountId}")]
        public async Task Hesoyam(int accountId)
        {
            var u = await db.User.FirstOrDefaultAsync(x => x.Id == accountId);
            u.Balance += 250000;
            db.User.Update(u);
            await db.SaveChangesAsync();
        }
    }
}
