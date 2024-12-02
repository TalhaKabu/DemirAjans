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
    public Guid ImageName { get; protected set; }
    public bool AppearInFront { get; protected set; }

    public Category(string name, Guid imageName, bool appearInFront)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetImageName(imageName);
        SetAppearInFront(appearInFront);
    }

    public Category(int id, string name, Guid imageName, bool appearInFront)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetImageName(imageName);
        SetAppearInFront(appearInFront);
    }

    private void SetAppearInFront(bool appearInFront)
    {
        AppearInFront = appearInFront;
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