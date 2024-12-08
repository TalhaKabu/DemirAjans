using Kab.DemirAjans.Business.Categories;
using Kab.DemirAjans.Business.SubCategories;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.SubCategories;
using System.Xml.Linq;
using System;

namespace Kab.DemirAjans.Business.Helper.ProductHelper;

public class CategoryHelper(ICategoryService categoryService, ISubCategoryService subCategoryService)
{
    public async Task GetAndSaveCategoriesAsync()
    {
        var url = "https://api.turkuazpromosyon.com.tr/xml/index.php?type=kategoriler&imgUrl=1&key=7e74556d2c9a4a32b8ecd3589ad143b3";

        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string xmlContent = await response.Content.ReadAsStringAsync();

            XDocument xmlDoc = XDocument.Parse(xmlContent);

            foreach (var ct in xmlDoc.Descendants("kategoriler"))
            {
                if (Int32.Parse(ct.Element("ustkid")?.Value) == 0)
                {
                    try
                    {
                        string kid = ct.Element("kid")?.Value;
                        //string ustkid = ct.Element("ustkid")?.Value;
                        string isim = ct.Element("isim")?.Value;
                        string resim = ct.Element("resim")?.Value;

                        var category = new CategoryCreateDto();
                        category.Name = isim;
                        category.AppearInFront = false;
                        category.Kid = Int32.Parse(kid);

                        var base64 = string.Empty;
                        byte[] imageBytes = await client.GetByteArrayAsync(resim);
                        category.Base64 = Convert.ToBase64String(imageBytes);


                        await categoryService.InsertAsync(category);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            foreach (var ct in xmlDoc.Descendants("kategoriler"))
            {
                if (Int32.Parse(ct.Element("ustkid")?.Value) > 0)
                {
                    try
                    {
                        string kid = ct.Element("kid")?.Value;
                        string ustkid = ct.Element("ustkid")?.Value;
                        string isim = ct.Element("isim")?.Value;
                        string resim = ct.Element("resim")?.Value;

                        var category = await categoryService.GetByKidAsync(Int32.Parse(ustkid));

                        var subCategory = new SubCategoryCreateDto();
                        subCategory.Name = isim;
                        subCategory.CategoryId = category.Id;
                        subCategory.Skid = Int32.Parse(kid);

                        var base64 = string.Empty;
                        byte[] imageBytes = await client.GetByteArrayAsync(resim);
                        subCategory.Base64 = Convert.ToBase64String(imageBytes);

                        await subCategoryService.InsertAsync(subCategory);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}