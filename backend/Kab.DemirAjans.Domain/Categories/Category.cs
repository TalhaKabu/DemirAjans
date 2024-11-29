using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using Kab.DemirAjans.Domain.ExtraProperties;
using Kab.DemirAjans.Domain.Products;

namespace Kab.DemirAjans.Domain.Categories;

public class Category : AuditedAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(CategoryConst.MaxNameLength)]
    public required string Name { get; set; }
    public List<Product> Products { get; set; }
}