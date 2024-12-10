using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.Business.Products
{
    public interface IProductService
    {
        Task<ProductDto?> GetAsync(int id);
        Task<ProductDto?> GetByCodeAsync(string code);
        Task<IEnumerable<ProductDto>> GetListAsync();
        Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront);
        Task<IEnumerable<ProductDto>> GetListByCategoryIdAndSubCategoryIdAsync(int categoryId, int? subCategoryId);
        Task<int> InsertAsync(ProductCreateDto create);
        Task UpdateAsync(int id, ProductUpdateDto update);
    }
}