using PassingTrips.Dtos;
using PassingTrips.Models;

namespace PassingTrips.Abstractions;

public interface ITripRepository
{
    Task AddTrip(Trip trip);
    List<Trip> GetTripsByCitiesTime(FindTripByCitiesDto findTripByCitiesDto);
    List<Trip> GetTripsByTime(DateTime day);
    Task<Trip> GetTripById(int id);
}