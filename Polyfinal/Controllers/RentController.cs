using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/rent")]
    public class RentController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet("Transport")]
        public async Task<ActionResult<List<Rent>>> GetTransport()
        {
            var rent = await db.Rent.ToListAsync();
            return Ok(rent);
        }

        [HttpGet("/{rentId}")]
        public async Task<ActionResult<Rent>> GetTransportId(int rentId)
        {
            var rent = await db.Rent.FirstOrDefaultAsync(x => x.Id == rentId);
            return Ok(rent);
        }

        [HttpGet("MyHistory")]
        public async Task<ActionResult<List<Rent>>> MyHistory(User user)
        {
            List<Rent> history = await db.Rent.Where(x => x.UserId == user.Id).ToListAsync();
            return Ok(history);
        }

        [HttpGet("TransportHistory/{transportId}")]
        public async Task<ActionResult<List<Rent>>> TransportHistory(int transportId)
        {
            List<Rent> history = await db.Rent.Where(x => x.TransportId == transportId).ToListAsync();
            return Ok(history);
        }

        [HttpPost("New/{transportId}")]
        public async Task New(int transportId, string rentType)
        {
            Rent rent = new Rent();
            rent.Type = rentType;
            rent.TransportId = transportId;
            db.Rent.Add(rent);
            await db.SaveChangesAsync();
        }

        [HttpPost("End/{rentId}")]
        public async Task End(int rentId)
        {
            var rent = await db.Rent.FirstOrDefaultAsync(x => x.Id == rentId);
            rent.TransportId = 0;
            db.Rent.Add(rent);
            await db.SaveChangesAsync();
        }
    }
}
