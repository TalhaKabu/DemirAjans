using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.Categories;

public class CategoryDto : AggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid? ImageName { get; set; }
    public string Base64 { get; set; }
}