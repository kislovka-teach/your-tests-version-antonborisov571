using PassingTrips.Models;

namespace PassingTrips.Abstractions;

public interface IUserRepository
{
    Task<User> GetUserByLoginPassword(string login, string password);
}