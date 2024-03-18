using PassingTrips.Abstractions;
using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Services;

public class FindTripsByCoordinatesService(ITripRepository tripRepository) : IFindTripsByCoordinates
{
    public List<Trip> GetTripsByCoordinates(FindTripByCoordinatesDto findTripDto)
    {
        var trips = tripRepository.GetTripsByTime(findTripDto.Date)
            .Where(trip => GetDistance(trip.DepartureCity.Coordinate, findTripDto.DepartureCity) < 20
                           && GetDistance(trip.ArrivalCity.Coordinate, findTripDto.ArrivalCity) < 20)
            .ToList();
        return trips;
    }

    public double GetDistance(Coordinate a, Coordinate b)
    {
        return Math.Acos(Math.Sin(a.Width) * Math.Sin(b.Width)
                         + Math.Cos(a.Width) * Math.Sin(b.Width) * Math.Cos(a.Longitude - b.Longitude)) * 6371;
    }
}