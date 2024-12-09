namespace Kab.DemirAjans.Entities.Products;

public class ProductUpdateDto
{
    public string? Name { get; set; }
    public int? CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string? Code { get; set; }
    public string? GroupCode { get; set; }
    public decimal? Price { get; set; }
    public string? Dimension { get; set; }
    public bool? AppearInFront { get; set; }
    public string? Header { get; set; }
    public string? Print { get; set; }
    public string? Description { get; set; }
    public int? Vat { get; set; }
    public int? Uid { get; set; }
}