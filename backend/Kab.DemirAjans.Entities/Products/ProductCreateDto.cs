using Kab.DemirAjans.Entities.Images;
using System;

namespace Kab.DemirAjans.Entities.Products;

public class ProductCreateDto
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string? Dimension { get; set; }
    public List<ImageCreateDto> Images { get; set; }
}