using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Helper.ProductHelper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.SubCategories;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoryController(ISubCategoryService subCategoryService) : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService = subCategoryService;

    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync() => Ok(await _subCategoryService.GetListAsync());

    [HttpGet("by-category-id")]
    public async Task<IActionResult> GetByCategoryIdAsync(int id) => Ok(await _subCategoryService.GetByCategoryIdAsync(id));

    [HttpGet("get")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var subCategoryDto = await _subCategoryService.GetAsync(id);

        if (subCategoryDto != null)
            return Ok(subCategoryDto);
        else
            return NotFound();
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(SubCategoryCreateDto create)
    {
        await _subCategoryService.InsertAsync(create);
        return Ok();
    }

    [HttpGet("get-product")]
    public async Task GetProducts() => ProductHelper.GetProductsFromUri();
}
