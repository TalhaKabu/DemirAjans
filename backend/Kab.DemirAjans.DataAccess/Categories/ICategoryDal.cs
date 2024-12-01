using Kab.DemirAjans.Entities.Categories;

namespace Kab.DemirAjans.DataAccess.Categories;

public interface ICategoryDal
{
    Task<CategoryDto?> GetAsync(int id);
    Task<IEnumerable<CategoryDto>> GetListAsync();
    Task InsertAsync(CategoryDto categoryDto);
}