using Kab.DemirAjans.Entities.SubCategories;

namespace Kab.DemirAjans.DataAccess.SubCategories;

public interface ISubCategoryDal
{
    Task<SubCategoryDto?> GetAsync(int id);
    Task<SubCategoryDto?> GetBySkidAsync(int skid);
    Task<IEnumerable<SubCategoryDto>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<SubCategoryDto>> GetListAsync();
    Task InsertAsync(SubCategoryDto subCategoryDto);
    Task UpdateAsync(int id, SubCategoryDto subCategoryDto);
}