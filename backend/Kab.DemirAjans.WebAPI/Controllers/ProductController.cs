using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync() => Ok(await _productService.GetListAsync());

    [HttpGet("get")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var categoryDto = await _productService.GetAsync(id);

        if (categoryDto != null)
            return Ok(categoryDto);
        else
            return NotFound();
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(ProductCreateDto create)
    {
        await _productService.InsertAsync(create);
        return Ok();
    }
}
