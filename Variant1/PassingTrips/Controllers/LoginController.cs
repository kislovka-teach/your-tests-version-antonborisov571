using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PassingTrips.Abstractions;
using PassingTrips.Options;

namespace PassingTrips.Controllers;

public class LoginController(ILoginHelper loginHelper) : ControllerBase
{
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] string login, [FromBody] string password)
    {
        var identity = await loginHelper.GetIdentity(login, password);
        var result = await loginHelper.GetToken(identity);
        if (result.IsSuccess)
        {
            var response = new
            {
                access_token = result.JwtToken,
                username = identity.Name
            };

            return new JsonResult(response);
        }
        else
            return BadRequest(result.ErrorMessage);

    }
}