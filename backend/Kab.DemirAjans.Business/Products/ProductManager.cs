using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.DataAccess.Products;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.Business.Products;

public class ProductManager(IProductDal productDal, ISubCategoryService subCategoryService, ICategoryService categoryService) : IProductService
{
    private readonly IProductDal _productDal = productDal;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;
    private readonly ICategoryService _categoryService = categoryService;

    public async Task<IEnumerable<ProductDto>> GetListAsync() => await _productDal.GetListAsync();

    public async Task<ProductDto?> GetAsync(int id) => await _productDal.GetAsync(id);

    public async Task InsertAsync(ProductCreateDto create)
    {
        if (create.Images.Count < 1) throw new Exception("Ürünler en az bir fotoğrafa sahip olmak zorundadır!");

        var categoryDto = await _categoryService.GetAsync(create.CategoryId) ?? throw new ArgumentException("Kategori bulunamadı!");

        if (create.SubCategoryId > 0)
        {
            var subCategoryDto = await _subCategoryService.GetAsync(create.SubCategoryId) ?? throw new ArgumentException("Alt kategori bulunamadı!");

            if (subCategoryDto.CategoryId != categoryDto.Id) throw new ArgumentException("Kategori ve alt kategori uyuşmuyor!");
        }

        //var product = new Product(create.Name,
        //                          create.CategoryId,
        //                          create.SubCategoryId,
        //                          create.Code,
        //                          create.GroupCode,
        //                          create.Price,
        //                          create.AppearInFront,
        //                          create.Header,
        //                          create.Vat,
        //                          create.Uid,
        //                          create.Dimension,
        //                          create.Print,
        //                          create.Description
        //                          );

        //var productId = await _productDal.InsertAsync(ObjectMapper.Mapper.Map<Product, ProductDto>(product));
    }

    public async Task UpdateAsync(int id, ProductUpdateDto update)
    {
        //todo product appear in front orn. en fazla 4 tane ise kontrol et
        //var product = await GetAsync(id);

        //var pr = new Product(id,
        //                     update.Name ?? product.Name,
        //                     update.CategoryId ?? product.CategoryId,
        //                     update.SubCategoryId ?? product.SubCategoryId,
        //                     update.Code ?? product.Code,
        //                     update.GroupCode ?? product.GroupCode,
        //                     update.Price ?? product.Price,
        //                     update.AppearInFront ?? product.AppearInFront,
        //                     update.Header ?? product.Header,
        //                     update.Vat ?? product.Vat,
        //                     update.Uid ?? product.Uid,
        //                     update.Dimension ?? product.Dimension,
        //                     update.Print ?? product.Print,
        //                     update.Description ?? product.Description
        //                     );

        //await _productDal.UpdateAsync(id, ObjectMapper.Mapper.Map<Product, ProductDto>(pr));
    }

    public async Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront)
    {
        var productList = await _productDal.GetListByAppearInFrontAsync(appearInFront) ?? [];

        return productList;
    }
}