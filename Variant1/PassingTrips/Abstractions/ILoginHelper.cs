using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace PassingTrips.Abstractions;

public interface ILoginHelper
{
    Task<ClaimsIdentity> GetIdentity(string login, string password);
    Task<LoginTokenDto> GetToken(ClaimsIdentity identity);
}