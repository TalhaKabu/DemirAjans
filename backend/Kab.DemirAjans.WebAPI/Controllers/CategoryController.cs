﻿using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Entities.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync() => Ok(await _categoryService.GetListAsync());

    [HttpGet("list-by-appear-in-front")]
    public async Task<IActionResult> GetListByAppearInFrontAsnc(bool appearInFront) => Ok(await _categoryService.GetListByAppearInFrontAsnc(appearInFront));

    [HttpGet("get")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var categoryDto = await _categoryService.GetAsync(id);

        if (categoryDto != null)
            return Ok(categoryDto);
        else
            return NotFound();
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(CategoryCreateDto create)
    {
        await _categoryService.InsertAsync(create);
        return Ok();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync(int id, CategoryUpdateDto update)
    {
        await _categoryService.UpdateAsync(id, update);
        return Ok();
    }
}
