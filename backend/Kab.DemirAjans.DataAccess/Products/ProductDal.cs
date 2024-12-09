using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.DataAccess.Products;

public class ProductDal(ISqlDataAccess db) : IProductDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<ProductDto>> GetListAsync() => await _db.LoadDataAsync<ProductDto, dynamic>(storedProcedure: "dbo.spProducts_GetAll", new { });
    public async Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront) => await _db.LoadDataAsync<ProductDto, dynamic>(storedProcedure: "dbo.spProducts_GetAllByAppearInFront", new { AppearInFront = appearInFront });
    public async Task<ProductDto?> GetAsync(int id) => (await _db.LoadDataAsync<ProductDto, dynamic>(storedProcedure: "dbo.spProducts_Get", new { Id = id })).FirstOrDefault();
    public async Task<int> InsertAsync(ProductDto productDto) => await _db.SaveDataReturnIdAsync(
        storedProcedure: "dbo.spProducts_Insert",
        new { productDto.Name, productDto.CategoryId, productDto.SubCategoryId, productDto.Code, productDto.Price, productDto.Dimension, productDto.AppearInFront, productDto.ImageName, productDto.PrintExp, productDto.Description, productDto.Vat, productDto.CreationDate, productDto.LastModificationDate });
    public async Task UpdateAsync(int id, ProductDto productDto) => await _db.SaveDataAsync(
        storedProcedure: "spProducts_Update",
        new { Id = id, productDto.Name, productDto.Code, productDto.Price, productDto.Dimension, productDto.CategoryId, productDto.SubCategoryId, productDto.AppearInFront, productDto.ImageName, productDto.PrintExp, productDto.Description, productDto.Vat, productDto.LastModificationDate });
}