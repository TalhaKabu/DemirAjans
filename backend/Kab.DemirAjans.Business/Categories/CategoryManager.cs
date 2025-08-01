﻿using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Entities.Categories;
using System;

namespace Kab.DemirAjans.Business.Categories;

public class CategoryManager(ICategoryDal categoryDal, ISubCategoryService subCategoryService) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;

    public async Task<IEnumerable<CategoryDto>> GetListAsync()
    {
        var categoryList = await _categoryDal.GetListAsync();

        List<Task> tasks = [];

        foreach (var categoryDto in categoryList)
        {
            tasks.Add(Task.Run(() =>
            {
                categoryDto.subCategoryList = _subCategoryService.GetByCategoryIdAsync(categoryDto.Id).Result;
            }));
        }

        await Task.WhenAll(tasks);

        return categoryList;
    }

    public async Task<IEnumerable<CategoryDto>> GetListByAppearInFrontAsnc(bool appearInFront) => await _categoryDal.GetListByAppearInFrontAsync(appearInFront);

    public async Task<CategoryDto?> GetAsync(int id) => await _categoryDal.GetAsync(id);

    public async Task<CategoryDto?> GetByKidAsync(int kid) => await _categoryDal.GetByKidAsync(kid);

    public async Task InsertAsync(CategoryCreateDto create)
    {
        var guid = string.IsNullOrEmpty(create.Base64) ? Guid.Empty : await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Category));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        try
        {
            var category = new Category(create.Name, guid, !string.IsNullOrEmpty(create.Base64) && create.AppearInFront, create.Kid);

            await _categoryDal.InsertAsync(ObjectMapper.Mapper.Map<Category, CategoryDto>(category));
        }
        catch (Exception ex)
        {
            if (guid != Guid.Empty)
                await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Category));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }

    public async Task UpdateAsync(int id, CategoryUpdateDto update)
    {
        var category = await GetAsync(id);

        var guid = category!.ImageName;

        if (!string.IsNullOrEmpty(update.Base64))
        {
            guid = await Task.Run(() => ImageHelper.SaveImage(update.Base64, ImageEnum.Category));

            if (string.IsNullOrEmpty(guid.ToString()))
                throw new ArgumentException("Fotoğraf oluşturulamadı!");

            await Task.Run(() => ImageHelper.DeleteImage(category.ImageName, ImageEnum.Category));
        }

        try
        {
            var ct = new Category(
                id,
                update.Name ?? category.Name,
                guid,
                update.AppearInFront ?? category.AppearInFront,
                category.Kid);

            await _categoryDal.UpdateAsync(id, ObjectMapper.Mapper.Map<Category, CategoryDto>(ct));
        }
        catch (Exception ex)
        {
            await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Category));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }
}