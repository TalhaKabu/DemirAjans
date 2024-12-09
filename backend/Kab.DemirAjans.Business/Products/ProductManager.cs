using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.DataAccess.Products;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.Colors;
using Kab.DemirAjans.Entities.Products;

namespace Kab.DemirAjans.Business.Products;

public class ProductManager(IProductDal productDal, ISubCategoryService subCategoryService, ICategoryService categoryService) : IProductService
{
    private readonly IProductDal _productDal = productDal;
    private readonly ISubCategoryService _subCategoryService = subCategoryService;
    private readonly ICategoryService _categoryService = categoryService;

    public async Task<IEnumerable<ProductDto>> GetListAsync() => await _productDal.GetListAsync();

    public async Task<ProductDto?> GetAsync(int id) => await _productDal.GetAsync(id);

    public async Task<ProductDto?> GetByCodeAsync(string code) => await _productDal.GetByCodeAsync(code);

    public async Task<int> InsertAsync(ProductCreateDto create)
    {
        if (string.IsNullOrEmpty(create.Base64)) throw new Exception("Ürünler en az bir fotoğrafa sahip olmak zorundadır!");

        var categoryDto = await _categoryService.GetAsync(create.CategoryId) ?? throw new ArgumentException("Kategori bulunamadı!");

        if (create.SubCategoryId > 0)
        {
            var subCategoryDto = await _subCategoryService.GetAsync(create.SubCategoryId) ?? throw new ArgumentException("Alt kategori bulunamadı!");

            if (subCategoryDto.CategoryId != categoryDto.Id) throw new ArgumentException("Kategori ve alt kategori uyuşmuyor!");
        }

        var guid = await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Product));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        try
        {
            var product = new Product(create.Name,
                          create.CategoryId,
                          create.SubCategoryId,
                          create.Code,
                          create.Price,
                          create.AppearInFront,
                          create.Vat,
                          guid,
                          create.Dimension,
                          create.PrintExp,
                          create.Description
                          );

            var productId = await _productDal.InsertAsync(ObjectMapper.Mapper.Map<Product, ProductDto>(product));

            return productId;
        }
        catch (Exception ex)
        {
            if (guid != Guid.Empty)
                await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Product));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }

    public async Task UpdateAsync(int id, ProductUpdateDto update)
    {
        var product = await GetAsync(id);

        var guid = product!.ImageName;

        if (!string.IsNullOrEmpty(update.Base64))
        {
            guid = await Task.Run(() => ImageHelper.SaveImage(update.Base64, ImageEnum.Product));

            if (string.IsNullOrEmpty(guid.ToString()))
                throw new ArgumentException("Fotoğraf oluşturulamadı!");

            await Task.Run(() => ImageHelper.DeleteImage(product.ImageName, ImageEnum.Product));
        }

        try
        {
            //todo product appear in front orn. en fazla 4 tane ise kontrol et
            var pr = new Product(id,
                                 update.Name ?? product.Name,
                                 update.CategoryId ?? product.CategoryId,
                                 update.SubCategoryId ?? product.SubCategoryId,
                                 update.Code ?? product.Code,
                                 update.Price ?? product.Price,
                                 update.AppearInFront ?? product.AppearInFront,
                                 update.Vat ?? product.Vat,
                                 guid,
                                 update.Dimension ?? product.Dimension,
                                 update.PrintExp ?? product.PrintExp,
                                 update.Description ?? product.Description
                                 );

            await _productDal.UpdateAsync(id, ObjectMapper.Mapper.Map<Product, ProductDto>(pr));
        }
        catch (Exception ex)
        {
            await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Product));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }

    public async Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront)
    {
        var productList = await _productDal.GetListByAppearInFrontAsync(appearInFront) ?? [];

        return productList;
    }
}