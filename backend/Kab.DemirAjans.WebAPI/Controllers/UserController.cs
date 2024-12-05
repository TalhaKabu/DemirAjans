using Kab.DemirAjans.Business.Users;
using Kab.DemirAjans.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(UserCreateDto create)
    {
        await _userService.InsertAsync(create);
        return Ok();
    }

    [HttpGet("get")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var user = HttpContext.User;

        var userDto = await _userService.GetAsync(id);
        if(userDto != null)
            return Ok(userDto);
        else
            return NotFound();
    }
}
