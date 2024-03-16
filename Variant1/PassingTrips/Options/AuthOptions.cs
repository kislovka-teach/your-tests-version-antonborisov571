using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PassingTrips.Options;

public class AuthOptions
{
    public const string Issuer = "MyAuthServer"; 
    public const string Audience = "MyAuthClient"; 
    const string Key = "123"; 
    public const int Lifetime = 3; 
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}