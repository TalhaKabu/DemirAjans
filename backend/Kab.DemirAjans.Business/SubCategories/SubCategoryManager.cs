using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.SubCategories;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.SubCategories;
using System;

namespace Kab.DemirAjans.Business.SubCategories;

public class SubCategoryManager(ISubCategoryDal subCategoryDal) : ISubCategoryService
{
    private readonly ISubCategoryDal _subCategoryDal = subCategoryDal;

    public async Task<IEnumerable<SubCategoryDto>> GetListAsync() => await _subCategoryDal.GetListAsync();

    public async Task<IEnumerable<SubCategoryDto>> GetByCategoryIdAsync(int categoryId) => await _subCategoryDal.GetByCategoryIdAsync(categoryId);

    public async Task<SubCategoryDto?> GetAsync(int id) => await _subCategoryDal.GetAsync(id);

    public async Task InsertAsync(SubCategoryCreateDto create)
    {
        var guid = string.IsNullOrEmpty(create.Base64) ? Guid.Empty : await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Category));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        try
        {
            var subCategory = new SubCategory(create.Name, guid, create.CategoryId, create.Skid);

            await _subCategoryDal.InsertAsync(ObjectMapper.Mapper.Map<SubCategory, SubCategoryDto>(subCategory));
        }
        catch (Exception ex)
        {
            if (guid != Guid.Empty)
                await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Category));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }

    public async Task UpdateAsync(int id, SubCategoryUpdateDto update)
    {
        var subCategory = await GetAsync(id);

        var guid = subCategory!.ImageName;

        if (!string.IsNullOrEmpty(update.Base64))
        {
            await Task.Run(() => ImageHelper.DeleteImage(subCategory.ImageName, ImageEnum.Category));
            guid = await Task.Run(() => ImageHelper.SaveImage(update.Base64, ImageEnum.Category));

            if (string.IsNullOrEmpty(guid.ToString()))
                throw new ArgumentException("Fotoğraf oluşturulamadı!");
        }

        try
        {
            var sct = new SubCategory(id,
                                  update.Name ?? subCategory.Name,
                                  guid,
                                  update.CategoryId ?? subCategory.CategoryId,
                                  subCategory.Skid);

            await _subCategoryDal.UpdateAsync(id, ObjectMapper.Mapper.Map<SubCategory, SubCategoryDto>(sct));
        }
        catch (Exception ex)
        {
            await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Category));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }


    }
}