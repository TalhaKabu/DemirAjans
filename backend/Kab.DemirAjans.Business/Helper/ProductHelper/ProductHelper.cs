using HtmlAgilityPack;
using System;
namespace Kab.DemirAjans.Business.Helper.ProductHelper;

public static class ProductHelper
{
    static List<string> uris = new List<string>
    {
        "https://www.promosyonfiyat.com/kategori.php?id=69",
        "https://www.promosyonfiyat.com/kategori.php?id=52"
    };
    public static void GetProductsFromUri()
    {

        var client = new System.Net.Http.HttpClient();
        foreach (var uri in uris)
        {
            var content = client.GetStringAsync(uri).Result;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);
            var elementGridNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'products elements-grid')]");
            foreach (var elementGridNode in elementGridNodes)
            {
                var imgNodes = elementGridNode.SelectNodes("//img[contains(@class, 'size-woocommerce_thumbnail')]");

                foreach (var imgNode in imgNodes)
                {

                }
            }
        }
    }
}