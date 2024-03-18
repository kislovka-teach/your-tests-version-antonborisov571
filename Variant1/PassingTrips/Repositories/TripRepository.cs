using Microsoft.EntityFrameworkCore;
using PassingTrips.Abstractions;
using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Repositories;

public class TripRepository(AppDbContext dbContext) : ITripRepository
{
    public async Task AddTrip(Trip trip)
    {
        await dbContext.Trips.AddAsync(trip);
        await dbContext.SaveChangesAsync();
    }

    public List<Trip> GetTripsByCitiesTime(FindTripByCitiesDto findTripByCitiesDto)
    {
        var trips = dbContext.Trips
            .Where(trip => 
                trip.DepartureCity.Name == findTripByCitiesDto.DepartureCity
                && trip.ArrivalCity.Name == findTripByCitiesDto.ArrivalCity
                && trip.ArrivalTime.Date == findTripByCitiesDto.Date
                && trip.ArrivalTime.TimeOfDay > DateTime.Now.TimeOfDay
                && trip.Passengers.Count < trip.MaxCountPassenger)
            .ToList();
        return trips;
    }

    public List<Trip> GetTripsByTime(DateTime day)
    {
        var trips = dbContext.Trips
                        .Include(trip => trip.DepartureCity)
                            .ThenInclude(city => city.Coordinate)
                        .Include(trip => trip.ArrivalCity)
                            .ThenInclude(city => city.Coordinate)
                        .Where(trip => 
                            trip.ArrivalTime.Date == day.Date
                            && trip.ArrivalTime.TimeOfDay > DateTime.Now.TimeOfDay
                            && trip.Passengers.Count < trip.MaxCountPassenger)
                        .ToList();
        return trips;
    }

    public async Task<Trip> GetTripById(int id)
    {
        var trip = await dbContext.Trips
            .Include(trip1 => trip1.Driver)
            .Include(trip1 => trip1.ArrivalCity)
            .Include(trip1 => trip1.DepartureCity)
            .Include(t => t.Passengers)
            .FirstOrDefaultAsync(t => t.Id == id &&
                             t.ArrivalTime > DateTime.Now &&
                             t.MaxCountPassenger > t.Passengers.Count);
        return trip;
    }
}