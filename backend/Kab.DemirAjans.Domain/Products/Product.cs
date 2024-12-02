using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;
using Kab.DemirAjans.Domain.Images;
using System;

namespace Kab.DemirAjans.Domain.Products;

public class Product : AuditedAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(ProductConst.NameMaxLength)]
    public required string Name { get; set; }
    public required int CategoryId { get; set; } 
    public int SubCategoryId { get; set; }
}