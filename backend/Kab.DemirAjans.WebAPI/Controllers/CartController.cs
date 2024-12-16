using Kab.DemirAjans.Business.Activations;
using Kab.DemirAjans.Business.Carts;
using Kab.DemirAjans.Entities.Activations;
using Kab.DemirAjans.Entities.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController(ICartService cartService) : ControllerBase
{
    private readonly ICartService _cartService = cartService; 

    [HttpPost("insert")]
    [Authorize]
    public async Task<IActionResult> InsertAsync(CartCreateDto create)
    {
        await _cartService.InsertAsync(create);
        return Ok(true);
    }

    [HttpGet("get-list-by-user-id")]
    [Authorize]
    public async Task<IActionResult> GetListByUserIdAsync(int id)
    {
        return Ok(await _cartService.GetListByUserIdAsync(id));
    }
}
