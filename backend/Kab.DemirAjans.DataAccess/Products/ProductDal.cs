using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Products;
using System;

namespace Kab.DemirAjans.DataAccess.Products;

public class ProductDal(ISqlDataAccess db) : IProductDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<ProductDto>> GetListAsync() => await _db.LoadDataAsync<ProductDto, dynamic>(storedProcedure: "dbo.spProducts_GetAll", new { });
    public async Task<ProductDto?> GetAsync(int id) => (await _db.LoadDataAsync<ProductDto, dynamic>(storedProcedure: "dbo.spProducts_Get", new { Id = id })).FirstOrDefault();
    public async Task<int> InsertAsync(ProductDto productDto) => await _db.SaveDataReturnIdAsync(storedProcedure: "dbo.spProducts_Insert",
        new { productDto.Name, productDto.CategoryId, productDto.SubCategoryId, productDto.Code, productDto.Price, productDto.CreationDate, productDto.LastModificationDate });
}