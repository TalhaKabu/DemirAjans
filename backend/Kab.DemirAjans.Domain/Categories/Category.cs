using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Domain.Images;
using System;

namespace Kab.DemirAjans.Domain.Categories;

public class Category : AuditedAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(CategoryConst.MaxNameLength)]
    public required string Name { get; set; }
    public List<Product> Products { get; set; }
    public Guid ImageName { get; set; }
}