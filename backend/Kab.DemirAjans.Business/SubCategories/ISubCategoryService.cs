using Kab.DemirAjans.Entities.SubCategories;

namespace Kab.DemirAjans.Business.SubCategories;

public interface ISubCategoryService
{
    Task<SubCategoryDto?> GetAsync(int id);
    Task<IEnumerable<SubCategoryDto>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<SubCategoryDto>> GetListAsync();
    Task InsertAsync(SubCategoryCreateDto create);
    Task UpdateAsync(int id, SubCategoryUpdateDto update);
}