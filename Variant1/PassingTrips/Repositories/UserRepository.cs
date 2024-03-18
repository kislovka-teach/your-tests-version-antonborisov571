using Microsoft.EntityFrameworkCore;
using PassingTrips.Abstractions;
using PassingTrips.Models;

namespace PassingTrips.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<User> GetUserByLoginPassword(string login, string password)
    {
        var user = await dbContext.Users.SingleAsync(user => 
            user.Login == login && user.Password == password);
        return user;
    }
    
    public async Task<User> GetDriverByTripId(int id)
    {
        var trip = await dbContext.Trips
            .Include(t => t.Driver)
                .ThenInclude(d => d.DriverTrips)
            .Include(t => t.Reviews)
                .ThenInclude(r => r.Sender)
            .SingleAsync(t => t.Id == id);
        var driver = trip.Driver;
        return driver;
    }
}