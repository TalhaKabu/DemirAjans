using Kab.DemirAjans.Entities.Categories;

namespace Kab.DemirAjans.DataAccess.Categories;

public interface ICategoryDal
{
    Task<CategoryDto?> GetAsync(int id);
    Task<CategoryDto?> GetByKidAsync(int kid);
    Task<IEnumerable<CategoryDto>> GetListAsync();
    Task<IEnumerable<CategoryDto>> GetListByAppearInFrontAsync(bool appearInFront);
    Task InsertAsync(CategoryDto categoryDto);
    Task UpdateAsync(int id, CategoryDto categoryDto);
}