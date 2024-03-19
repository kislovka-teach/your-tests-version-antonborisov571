using Freelance.Models;
using Freelance.Abstractions;

namespace Freelance.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> GetUserByLoginPassword(string login, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}