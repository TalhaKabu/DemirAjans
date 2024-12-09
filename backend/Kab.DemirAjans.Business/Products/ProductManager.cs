using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Images;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.DataAccess.Products;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Entities.Images;
using Kab.DemirAjans.Entities.Products;
using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        var categoryDto = await _categoryService.GetAsync(create.CategoryId) ?? throw new ArgumentException("Kategori bulunamadı!");

        if (create.SubCategoryId > 0)
        {
            var subCategoryDto = await _subCategoryService.GetAsync(create.SubCategoryId) ?? throw new ArgumentException("Alt kategori bulunamadı!");

            if (subCategoryDto.CategoryId != categoryDto.Id) throw new ArgumentException("Kategori ve alt kategori uyuşmuyor!");
        }

        var product = new Product(create.Name,
                                  create.CategoryId,
                                  create.SubCategoryId,
                                  create.Code,
                                  create.GroupCode,
                                  create.Price,
                                  create.AppearInFront,
                                  create.Header,
                                  create.Vat,
                                  create.Uid,
                                  create.Dimension,
                                  create.Print,
                                  create.Description
                                  );

        var productId = await _productDal.InsertAsync(ObjectMapper.Mapper.Map<Product, ProductDto>(product));

        foreach (var item in create.Images)
            await _imageService.InsertAsync(item, productId);
    }

    public async Task UpdateAsync(int id, ProductUpdateDto update)
    {
        //todo product appear in front orn. en fazla 4 tane ise kontrol et
        var product = await GetAsync(id);

        var pr = new Product(id,
                             update.Name ?? product.Name,
                             update.CategoryId ?? product.CategoryId,
                             update.SubCategoryId ?? product.SubCategoryId,
                             update.Code ?? product.Code,
                             update.GroupCode ?? product.GroupCode,
                             update.Price ?? product.Price,
                             update.AppearInFront ?? product.AppearInFront,
                             update.Header ?? product.Header,
                             update.Vat ?? product.Vat,
                             update.Uid ?? product.Uid,
                             update.Dimension ?? product.Dimension,
                             update.Print ?? product.Print,
                             update.Description ?? product.Description
                             );

        await _productDal.UpdateAsync(id, ObjectMapper.Mapper.Map<Product, ProductDto>(pr));
    }

    public async Task<IEnumerable<ProductDto>> GetListByAppearInFrontAsync(bool appearInFront)
    {
        var productList = await _productDal.GetListByAppearInFrontAsync(appearInFront) ?? [];

        List<Task<IEnumerable<ImageDto>>> tasks = [];
        foreach (var productDto in productList)
        {
            tasks.Add(Task.Run(() => _imageService.GetListByProductIdAsyns(productDto.Id)));
        }
        var results = await Task.WhenAll(tasks);

        List<Task<IEnumerable<ImageDto>>> tasks2 = [];
        foreach (var task in results)
        {
            tasks2.Add(Task.Run(() => productList.ToList().Find(x => x.Id == task.First().ProductId)!.Images = task));
        }
        await Task.WhenAll(tasks2);

        ; return productList;
    }
}