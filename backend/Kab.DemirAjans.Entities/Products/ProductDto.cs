using Kab.DemirAjans.Entities.ExtraProperties;

namespace Kab.DemirAjans.Entities.Products;

public class ProductDto : AggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public int Vat { get; set; }
    public bool AppearInFront { get; set; }
    public Guid ImageName { get; set; }
    public string? Dimension { get; set; }
    public string? PrintExp { get; set; }
    public string? Description { get; set; }
}