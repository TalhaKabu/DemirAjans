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
        try
        {
            var accessToken = await AuthService.Login(userLoginDto);

            if (accessToken != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,     // Prevents JavaScript from accessing the cookie
                    Secure = true,       // Ensure the cookie is sent only over HTTPS
                    SameSite = SameSiteMode.None,  // Prevents cross-site request forgery (CSRF)
                    Expires = DateTime.UtcNow.AddHours(1),  // Set an expiry for the cookie
                };

                //Response.Cookies.Append("token", accessToken.Token, cookieOptions);
                HttpContext.Response.Cookies.Append("token", accessToken.Token, cookieOptions);

                return Ok();
            }

            return Unauthorized();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
    }
}
