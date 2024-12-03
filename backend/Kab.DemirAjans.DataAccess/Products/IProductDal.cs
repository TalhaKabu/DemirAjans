using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.DataAccess.Products
{
    public interface IProductDal
    {
        Task<ProductDto?> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetListAsync();
        Task InsertAsync(ProductDto productDto);
    }
}