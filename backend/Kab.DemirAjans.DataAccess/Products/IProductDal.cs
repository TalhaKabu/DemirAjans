using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.DataAccess.Products
{
    public interface IProductDal
    {
        Task<ProductDto?> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetListAsync();
        Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront);
        Task<int> InsertAsync(ProductDto productDto);
        Task UpdateAsync(int id, ProductDto productDto);
    }
}