using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/transport")]
    public class TransportController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetTransport(int id)
        {
            var car = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(car);
        }

        [HttpPost]
        [Authorize]
        public async Task PostTransport(Car car)
        {
            db.Car.Add(car);
            await db.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task PutTransport(string newTransport, int id)
        {
            Car a = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            a.TransportType = newTransport;
            db.Car.Update(a);
            await db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteTransport(int id)
        {
            Car a = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            db.Car.Remove(a);
            await db.SaveChangesAsync();
        }
    }
}
