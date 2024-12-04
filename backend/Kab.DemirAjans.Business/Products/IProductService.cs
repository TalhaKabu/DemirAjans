using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.Business.Products
{
    public interface IProductService
    {
        Task<ProductDto?> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetListAsync();
        Task InsertAsync(ProductCreateDto create);
        Task UpdateAsync(int id, ProductUpdateDto update);
    }
}