using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.Products;

public class ProductDto : AggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string? Dimension { get; set; }
    public bool AppearInFront { get; set; }
}