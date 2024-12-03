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
        var subCategory = new SubCategory(create.Name, create.CategoryId);

        await _subCategoryDal.InsertAsync(ObjectMapper.Mapper.Map<SubCategory, SubCategoryDto>(subCategory));
    }
}