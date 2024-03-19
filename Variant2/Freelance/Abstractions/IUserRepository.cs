using Freelance.Models;

namespace Freelance.Abstractions;

public interface IUserRepository
{
    Task<User> GetUserByLoginPassword(string login, string hashedPassword);
}