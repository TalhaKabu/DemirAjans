using HtmlAgilityPack;
using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.Images;
using Kab.DemirAjans.Entities.Products;
using System;
using System.Buffers.Text;
using System.Xml;
namespace Kab.DemirAjans.Business.Helper.ProductHelper;

public class ProductHelper(IProductService productService, ISubCategoryService subCategoryService, ICategoryService categoryService)
{
    List<string> uris = new List<string>
    {
        //"https://www.promosyonfiyat.com/kategori.php?id=69"
        //"https://www.promosyonfiyat.com/kategori.php?id=23"
        //"https://www.promosyonfiyat.com/kategori.php?id=14"
        //"https://www.promosyonfiyat.com/kategori.php?id=15",
        //"https://www.promosyonfiyat.com/kategori.php?id=16"
        //"https://www.promosyonfiyat.com/kategori.php?id=61",
        //"https://www.promosyonfiyat.com/kategori.php?id=62",
        //"https://www.promosyonfiyat.com/kategori.php?id=63",
        //"https://www.promosyonfiyat.com/kategori.php?id=64"
        //"https://www.promosyonfiyat.com/kategori.php?id=56",
        //"https://www.promosyonfiyat.com/kategori.php?id=57",
        //"https://www.promosyonfiyat.com/kategori.php?id=58",
        //"https://www.promosyonfiyat.com/kategori.php?id=2",
        //"https://www.promosyonfiyat.com/kategori.php?id=3",
        //"https://www.promosyonfiyat.com/kategori.php?id=9",
        //"https://www.promosyonfiyat.com/kategori.php?id=10",
        //"https://www.promosyonfiyat.com/kategori.php?id=11",
        //"https://www.promosyonfiyat.com/kategori.php?id=52",
    };

    IProductService _productService = productService;
    ISubCategoryService _subCategoryService = subCategoryService;
    ICategoryService categoryService1 = categoryService;

    public async Task GetProductsFromUri()
    {
        var subCategoryList = await _subCategoryService.GetListAsync();
        var categoryList = await categoryService1.GetListAsync();


        var client = new System.Net.Http.HttpClient();
        foreach (var uri in uris)
        {
            var content = client.GetStringAsync(uri).Result;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);
            var baslik = document.DocumentNode.SelectSingleNode("//span[contains(@class, 'breadcrumb-last')]").InnerText.Trim();

            var elementGridNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'products elements-grid')]");

            var productGridItemNodes = elementGridNodes.First().SelectNodes("//div[contains(@class, 'product-grid-item')]");

            foreach (var productGridItemNode in productGridItemNodes)
            {
                var productelementtop = productGridItemNode.ChildNodes[1];

                // ilk img uri
                var aNodes = productelementtop.SelectSingleNode("a");

                var imgNode = aNodes.SelectSingleNode("img");

                var imageUrl = imgNode.GetAttributeValue("data-lazy-src",
                            imgNode.GetAttributeValue("src", "URL not found"));

                var base64 = string.Empty;
                byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                base64 = Convert.ToBase64String(imageBytes);

                // ikinci img uri
                var hoverimgnode = productelementtop.SelectSingleNode("div");

                var aNodes2 = hoverimgnode.SelectSingleNode("a");

                var imgNode2 = aNodes2.SelectSingleNode("img");

                var imageUrl2 = imgNode2.GetAttributeValue("data-lazy-src",
                           imgNode2.GetAttributeValue("src", "URL not found"));

                var base642 = string.Empty;
                byte[] imageBytes2 = await client.GetByteArrayAsync(imageUrl2);

                base642 = Convert.ToBase64String(imageBytes2);

                var h3node = productGridItemNode.SelectSingleNode("h3");
                var h3anode = h3node.SelectSingleNode("a");
                var productname = h3anode.InnerText.Trim();

                var pNodes = productGridItemNode.SelectNodes("p");
                var productDimension = pNodes[0].InnerText.ToString().Substring(pNodes[0].InnerText.ToString().IndexOf(";") + 1).Trim();
                var productCode = pNodes[1].InnerText.ToString().Substring(pNodes[1].InnerText.ToString().IndexOf(';') + 1).Trim();

                var spanNode = productGridItemNode.SelectSingleNode("span").SelectSingleNode("span").SelectSingleNode("bdi");
                var productprice = Decimal.Parse(spanNode.InnerText.ToString().Substring(0, spanNode.InnerText.ToString().IndexOf('&')));

                var subCategory = subCategoryList.ToList().Find(x => x.Name.Contains(baslik));

                var category = new CategoryDto();
                if (subCategory != null)
                {
                    category = categoryList.ToList().Find(x => x.Id == subCategory.CategoryId);
                }
                else
                {
                    category = categoryList.ToList().Find(x => x.Name.Contains(baslik));
                }

                if (category.Id != null)
                    await _productService.InsertAsync(new ProductCreateDto
                    {
                        Code = productCode,
                        Name = productname,
                        Dimension = productDimension,
                        Price = productprice < 1 ? 1 : productprice,
                        Images = [
                            new ImageCreateDto {
                            Base64 = base64,
                            IsFrontImage = true,
                        },new ImageCreateDto {
                            Base64 = base642,
                            IsFrontImage = false,
                        }
                        ],
                        CategoryId = category.Id,
                        SubCategoryId = subCategory.Id,
                    });

            }
        }
    }
}

public class ProductUrlDto
{
    public string Url { get; set; }
    public int Id { get; set; }
}