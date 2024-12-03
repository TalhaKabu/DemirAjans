using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.Categories;

public class CategoryCreateDto 
{
    public string Name { get; set; }
    public string? Base64 { get; set; }
    public bool AppearInFront { get; set; }
}