using Kab.DemirAjans.Entities.Categories;

namespace Kab.DemirAjans.Business.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetAsync(int id);
        Task<IEnumerable<CategoryDto>> GetListAsync();
        Task InsertAsync(CategoryDto categoryDto);
    }
}