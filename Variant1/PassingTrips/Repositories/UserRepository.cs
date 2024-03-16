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
}