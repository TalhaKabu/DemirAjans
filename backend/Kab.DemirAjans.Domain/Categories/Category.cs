using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;
using Kab.DemirAjans.Domain.Products;
using System;

namespace Kab.DemirAjans.Domain.Categories;

public class Category : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [MaxLength(CategoryConst.MaxNameLength)]
    [Required]
    public string Name { get; protected set; }

    [Required]
    public Guid ImageName { get; protected set; }

    public Category(int id, string name, Guid imageName)
    {
        Id = id;
        Name = name;
        ImageName = imageName;
    }
}