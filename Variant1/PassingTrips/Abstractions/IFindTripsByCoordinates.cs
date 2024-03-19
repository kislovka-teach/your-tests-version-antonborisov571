using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Abstractions;

public interface IFindTripsByCoordinates
{
    List<Trip> GetTripsByCoordinates(FindTripByCoordinatesDto findTripDto);
    double GetDistance(Coordinate a, Coordinate b);
}