using Kab.DemirAjans.Entities.Categories;

namespace Kab.DemirAjans.Business.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetAsync(int id);
        Task<IEnumerable<CategoryDto>> GetListAsync();
        Task<IEnumerable<CategoryDto>> GetListByAppearInFrontAsnc(bool appearInFront);
        Task InsertAsync(CategoryCreateDto categoryDto);
        Task UpdateAsync(int id, CategoryUpdateDto update);
    }
}