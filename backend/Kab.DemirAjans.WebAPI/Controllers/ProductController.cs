using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Colors;
using Kab.DemirAjans.Business.Helper.ProductHelper;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService, ISubCategoryService subCategoryService, ICategoryService categoryService, IColorService colorService) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IColorService _colorService = colorService;

    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync() => Ok(await _productService.GetListAsync());

    [HttpGet("list-by-appear-in-front")]
    public async Task<IActionResult> GetListByAppearInFrontAsync(bool appearInFront) => Ok(await _productService.GetListByAppearInFrontAsync(appearInFront));

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

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync(int id, ProductUpdateDto update)
    {
        await _productService.UpdateAsync(id, update);
        return Ok();
    }

    [HttpGet("get-categories-and-save")]
    public async Task GetCategoriesAndSaveAsync() => await new CategoryHelper(_categoryService, _subCategoryService).GetAndSaveCategoriesAsync();

    [HttpGet("get-products-and-save")]
    public async Task GetProductsAndSaveAsync() => await new ProductHelper(_productService, _subCategoryService, _categoryService, _colorService).GetProductsAndSaveAsync();
}
