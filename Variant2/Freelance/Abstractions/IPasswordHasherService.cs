namespace Freelance.Abstractions;

public interface IPasswordHasherService
{
    public byte[] GetSalt();
    public string GetHashPassword(string? password, byte[]? salt);
}