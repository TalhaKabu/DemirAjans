using Kab.DemirAjans.Business.Users;
using Kab.DemirAjans.Entities.Users;
using Microsoft.AspNetCore.Mvc;

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
}
