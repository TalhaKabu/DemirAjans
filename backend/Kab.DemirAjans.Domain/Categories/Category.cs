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

    public Category(string name, Guid imageName)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetImageName(imageName);
    }

    public Category(int id, string name, Guid imageName)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetImageName(imageName);
    }

    private void SetImageName(Guid imageName)
    {
        ImageName = imageName;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Kategori adi boş olamaz!");

        Name = name;
    }
}