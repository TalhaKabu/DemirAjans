using Kab.DemirAjans.Business.Token;
using Kab.DemirAjans.Business.Users;
using Kab.DemirAjans.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, ITokenService tokenService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly ITokenService _tokenService = tokenService;

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(UserCreateDto create)
    {
        await _userService.InsertAsync(create);
        return Ok();
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetAsync()
    {
        var jwtToken = Request.Cookies["token"];

        if (string.IsNullOrEmpty(jwtToken))
        {
            return Unauthorized("No valid session token found.");
        }

        // Validate the JWT token and extract user details
        var principal = _tokenService.ValidateToken(jwtToken);

        if (principal == null)
        {
            return Unauthorized("Invalid or expired token.");
        }

        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(userId);
    }
}
