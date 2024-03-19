using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Freelance;

public class AuthOptions
{
    public const string Issuer = "MyAuthServer"; 
    public const string Audience = "MyAuthClient"; 
    const string Key = "mysupersecretmysupersecretmysupersecretmysupersecretmysupersecret"; 
    public const int Lifetime = 3; 
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}