using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.DataAccess.Categories;
using Kab.DemirAjans.Entities.Categories;
using System;
namespace Kab.DemirAjans.Business.Categories;

public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;

    public async Task<IEnumerable<CategoryDto>> GetListAsync() => await _categoryDal.GetListAsync();
    public async Task<CategoryDto?> GetAsync(int id) => await _categoryDal.GetAsync(id);
    public async Task InsertAsync(CategoryDto categoryDto) 
    {
        //var guid = ImageHelper.SaveImage(categoryDto.Base64, ImageEnum.Category);

        //if (!string.IsNullOrEmpty(guid.ToString()))
            await _categoryDal.InsertAsync(categoryDto);
    }
}