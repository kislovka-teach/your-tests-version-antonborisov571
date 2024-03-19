using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Freelance.Abstractions;

namespace Freelance.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string GetHashPassword(string? password, byte[]? salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt!,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 1000,
            numBytesRequested: 32));

    }

    public byte[] GetSalt()
    {
        return RandomNumberGenerator.GetBytes(16);
    }
}