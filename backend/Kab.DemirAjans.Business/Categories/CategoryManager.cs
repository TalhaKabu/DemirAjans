using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Entities.Categories;
using System;
namespace Kab.DemirAjans.Business.Categories;

public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;

    public async Task<IEnumerable<CategoryDto>> GetListAsync() => await _categoryDal.GetListAsync();
    public async Task<CategoryDto?> GetAsync(int id) => await _categoryDal.GetAsync(id);
    public async Task<int> InsertAsync(CategoryCreateDto create)
    {
        var guid = await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Category));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        try
        {
            var category = new Category(create.Name, guid);

            var res = await _categoryDal.InsertAsync(ObjectMapper.Mapper.Map<Category, CategoryDto>(category));

            return res;
        }
        catch (Exception ex)
        {
            await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Category));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }
}