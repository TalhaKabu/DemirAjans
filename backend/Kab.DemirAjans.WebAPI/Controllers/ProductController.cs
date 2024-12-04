using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Helper.ProductHelper;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService, ISubCategoryService subCategoryService, ICategoryService categoryService) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;
    private readonly ICategoryService categoryService1 = categoryService;

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

    [HttpGet("get-product")]
    public async Task GetProducts() => await new ProductHelper(_productService, _subCategoryService, categoryService1).GetProductsFromUri();
}
