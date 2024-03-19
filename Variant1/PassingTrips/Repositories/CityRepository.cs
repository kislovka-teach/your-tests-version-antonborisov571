using Microsoft.EntityFrameworkCore;
using PassingTrips.Abstractions;
using PassingTrips.Models;

namespace PassingTrips.Repositories;

public class CityRepository(AppDbContext dbContext) : ICityRepository
{
    public async Task<City> GetCityByName(string name)
    {
        var city = await dbContext.Cities.FirstAsync(x => x.Name == name);
        return city;
    }
}