﻿using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.DataAccess.Products;

public interface IProductDal
{
    Task<ProductDto?> GetAsync(int id);
    Task<ProductDto?> GetByCodeAsync(string code);
    Task<IEnumerable<ProductDto>> GetListAsync();
    Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront);
    Task<IEnumerable<ProductDto>> GetListByCategoryIdAndAppearInFrontAsync(int categoryId, bool appearInFront);
    Task<IEnumerable<ProductDto>> GetListByCategoryIdAndSubCategoryIdAsync(int categoryId, int? subCategoryId);
    Task<int> InsertAsync(ProductDto productDto);
    Task UpdateAsync(int id, ProductDto productDto);
}