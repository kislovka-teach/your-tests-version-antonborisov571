using System.Security.Claims;
using Freelance.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Freelance.Abstractions;

public interface ILoginHelperService
{
    Task<ClaimsIdentity> GetIdentity(string login, string password);
    Task<LoginTokenDto> GetToken(ClaimsIdentity identity);
}