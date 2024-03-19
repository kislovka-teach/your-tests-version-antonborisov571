using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Freelance.Abstractions;
using Freelance.Dtos;
using Freelance;

namespace Freelance.Controllers;

[ApiController]
public class LoginController(ILoginHelperService loginHelperService) : ControllerBase
{
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        var identity = await loginHelperService.GetIdentity(userDto.Login, userDto.Password);
        var result = await loginHelperService.GetToken(identity);
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