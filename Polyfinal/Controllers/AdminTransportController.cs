using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyfinal.Data;
using Polyfinal.Models;

namespace Polyfinal.Controllers
{
    [ApiController]
    [Route("api/admin/transport")]
    public class AdminTransportController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAdminCar()
        {
            var cars = await db.Car.ToListAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetAdminCarId(int id)
        {
            var car = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(car);
        }

        [HttpPost]
        public async Task PostAdminCar(bool? canBeRented, string? transportType, string? model, string? color, string? identifier, string? description, double? latitude, double? longitude, double? minutePrice, double? dayPrice)
        {
            Car car = new Car()
            {
                CanBeRented = canBeRented,
                TransportType = transportType,
                Model = model,
                Color = color,
                Identifier = identifier,
                Description = description,
                Latitude = latitude,
                Longitude = longitude,
                MinutePrice = minutePrice,
                DayPrice = dayPrice
            };
            db.Car.Add(car);
            await db.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task PutAdminCar(int id, bool? canBeRented, string? transportType, string? model, string? color, string? identifier, string? description, double? latitude, double? longitude, double? minutePrice, double? dayPrice)
        {
            var car = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            car.CanBeRented = canBeRented;
            car.TransportType = transportType;
            car.Model = model;
            car.Color = color;
            car.Identifier = identifier;
            car.Description = description;
            car.Latitude = latitude;
            car.Longitude = longitude;
            car.MinutePrice = minutePrice;
            car.DayPrice = dayPrice;
            db.Car.Update(car);
            await db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAdminCar(int id)
        {
            var car = await db.Car.FirstOrDefaultAsync(x => x.Id == id);
            db.Car.Remove(car);
            await db.SaveChangesAsync();
        }
    }
}
