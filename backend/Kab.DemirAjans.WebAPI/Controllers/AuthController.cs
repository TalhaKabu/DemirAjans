using Kab.DemirAjans.Business.Auth;
using Kab.DemirAjans.Entities.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService AuthService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto userLoginDto)
    {
        return Ok(await AuthService.Login(userLoginDto));
    }
}
