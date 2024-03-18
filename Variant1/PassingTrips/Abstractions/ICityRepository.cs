using PassingTrips.Models;

namespace PassingTrips.Abstractions;

public interface ICityRepository
{
    Task<City> GetCityByName(string name);
}