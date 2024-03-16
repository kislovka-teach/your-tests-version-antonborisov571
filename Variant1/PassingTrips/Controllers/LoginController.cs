using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PassingTrips.Abstractions;
using PassingTrips.Dtos;
using PassingTrips.Options;

namespace PassingTrips.Controllers;

[ApiController]
public class LoginController(ILoginHelper loginHelper) : ControllerBase
{
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        var identity = await loginHelper.GetIdentity(userDto.Login, userDto.Password);
        var result = await loginHelper.GetToken(identity);
        if (result.IsSuccess)
        {
            var response = new
            {
                access_token = result.JwtToken,
                type = "bearer"
            };

            return Ok(response);
        }
        return BadRequest(result.ErrorMessage);

    }
}