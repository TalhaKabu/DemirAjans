using System;

namespace Kab.DemirAjans.Entities.SubCategories;

public class SubCategoryUpdateDto
{
    public string? Name { get; set; }
    public string? Base64 { get; set; }
    public int? CategoryId { get; set; }
}