using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Images;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.DataAccess.Products;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Entities.Products;
using System;

namespace Kab.DemirAjans.Business.Products;

public class ProductManager(IProductDal productDal, ISubCategoryService subCategoryService, ICategoryService categoryService, IImageService imageService) : IProductService
{
    private readonly IProductDal _productDal = productDal;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IImageService _imageService = imageService;

    public async Task<IEnumerable<ProductDto>> GetListAsync() => await _productDal.GetListAsync();

    public async Task<ProductDto?> GetAsync(int id) => await _productDal.GetAsync(id);

    public async Task InsertAsync(ProductCreateDto create)
    {
        if (create.Images.Count < 1) throw new Exception("Ürünler en az bir fotoğrafa sahip olmak zorundadır!");

        foreach (var item in create.Images)
            await _imageService.InsertAsync(item);

        var categoryDto = await _categoryService.GetAsync(create.CategoryId) ?? throw new ArgumentException("Kategori bulunamadı!");

        if (create.SubCategoryId > 0)
        {
            var subCategoryDto = await _subCategoryService.GetAsync(create.SubCategoryId) ?? throw new ArgumentException("Alt kategori bulunamadı!");

            if (subCategoryDto.CategoryId != categoryDto.Id) throw new ArgumentException("Kategori ve alt kategori uyuşmuyor!");
        }

        var product = new Product(create.Name, create.CategoryId, create.CategoryId, create.Code, create.Price, create.Dimension);

        await _productDal.InsertAsync(ObjectMapper.Mapper.Map<Product, ProductDto>(product));
    }
}