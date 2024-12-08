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
    public int Kid { get; protected set; }

    public Category(string name, Guid imageName, bool appearInFront, int kid)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetImageName(imageName);
        SetAppearInFront(appearInFront);
        SetKid(kid);
    }

    public Category(int id, string name, Guid imageName, bool appearInFront, int kid)
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
        if (name.Length > CategoryConst.MaxNameLength)
            throw new Exception($"Kategori adı {CategoryConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    private void SetKid(int kid)
    {
        if (kid < 1) throw new Exception();
        Kid = kid;
    }
}