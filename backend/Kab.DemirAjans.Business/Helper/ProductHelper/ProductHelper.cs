using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.Products;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.Images;
using Kab.DemirAjans.Entities.Products;
using System.Xml.Linq;

namespace Kab.DemirAjans.Business.Helper.ProductHelper;

public class ProductHelper(IProductService productService, ISubCategoryService subCategoryService, ICategoryService categoryService)
{
    public async Task GetProductsAndSaveAsync()
    {
        var url = "https://api.turkuazpromosyon.com.tr/xml/index.php?type=urunler&imgUrl=1&key=7e74556d2c9a4a32b8ecd3589ad143b3";

        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string xmlContent = await response.Content.ReadAsStringAsync();

            XDocument xmlDoc = XDocument.Parse(xmlContent);

            foreach (XElement ct in xmlDoc.Descendants("urunler"))
            {
                try
                {
                    string isim = ct.Element("isim")?.Value;
                    string baslik = ct.Element("baslik")?.Value;
                    string renk = ct.Element("renk")?.Value;
                    string aciklama = ct.Element("aciklama")?.Value;
                    string kod = ct.Element("kod")?.Value;
                    string ebat = ct.Element("ebat")?.Value;
                    string fiyat = ct.Element("fiyat")?.Value;
                    string kid = ct.Element("kid")?.Value;
                    string uid = ct.Element("uid")?.Value;
                    string kdv = ct.Element("kdv")?.Value;
                    string resim1 = ct.Element("resim1")?.Value;
                    string kodgrupResim = ct.Element("kodgrupResim")?.Value;

                    if (string.IsNullOrEmpty(resim1) || string.IsNullOrEmpty(kodgrupResim))
                        continue;

                    var subCategory = await subCategoryService.GetBySkidAsync(Int32.Parse(kid));
                    var category = await categoryService.GetAsync(subCategory.CategoryId);

                    var base64true = string.Empty;
                    byte[] imageBytes = await client.GetByteArrayAsync(resim1);
                    base64true = Convert.ToBase64String(imageBytes);

                    var base64false = string.Empty;
                    byte[] imageBytes2 = await client.GetByteArrayAsync(kodgrupResim);
                    base64false = Convert.ToBase64String(imageBytes2);

                    var product = new ProductCreateDto
                    {
                        Name = isim,
                        Header = baslik,
                        Color = renk,
                        Description = aciklama,
                        Code = kod,
                        Dimension = ebat,
                        Price = Decimal.Parse(fiyat),
                        Vat = Int32.Parse(kdv.Substring(0, kdv.IndexOf('.'))),
                        Uid = Int32.Parse(uid),
                        AppearInFront = false,
                        SubCategoryId = subCategory.Id,
                        CategoryId = category.Id,
                        Images = [
                            new ImageCreateDto {
                                IsFrontImage = true,
                                Base64 = base64true,
                            },
                            new ImageCreateDto {
                                IsFrontImage = false,
                                Base64 = base64false,
                            }
                        ]
                    };

                    await productService.InsertAsync(product);
                }
                catch (Exception ex)
                {
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}