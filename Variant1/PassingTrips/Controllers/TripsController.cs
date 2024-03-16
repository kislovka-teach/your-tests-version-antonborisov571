using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Controllers;

[ApiController]
[Route("/[controller]")]
public class TripsController(AppDbContext dbContext) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [Route("/add")]
    public async Task<IActionResult> AddTrip([FromBody]InputTripDto inputTripDto)
    {
        var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await dbContext.Trips.AddAsync(new Trip
        {
            DriverId = id,
            DepartureTime = inputTripDto.DepartureTime,
            ArrivalTime = inputTripDto.ArrivalTime,
            DepartureCityId = dbContext.Cities.First(x => x.Name == inputTripDto.DepartureCity).Id,
            ArrivalCityId = dbContext.Cities.First(x => x.Name == inputTripDto.ArrivalCity).Id,
            Price = inputTripDto.Price,
            MaxCountPassenger = inputTripDto.MaxCountPassenger,
            Car = inputTripDto.Car,
            IsMusic = inputTripDto.IsMusic,
            IsSmoking = inputTripDto.IsSmoking,
            IsAnimal = inputTripDto.IsAnimal
        });
        await dbContext.SaveChangesAsync();
        return Ok("Поездка добавлена");
    }
}