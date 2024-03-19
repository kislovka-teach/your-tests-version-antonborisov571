using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Freelance.Abstractions;
using Freelance.Dtos;

namespace Freelance.Services;

public class LoginHelperService(
    IUserRepository userRepository,
    IPasswordHasherService hasherService) : ILoginHelperService
{
    public async Task<ClaimsIdentity> GetIdentity(string login, string password)
    {
        var hashPassword = hasherService.GetHashPassword(password, new byte[]{});
        var user = await userRepository.GetUserByLoginPassword(login, hashPassword);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
        
        return null;
    }

    public async Task<LoginTokenDto> GetToken(ClaimsIdentity identity)
    {
        if (identity == null)
        {
            return new LoginTokenDto(false, "Пользователь не найден");
        }
 
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new LoginTokenDto(true, encodedJwt);
    }
}