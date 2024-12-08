using Kab.DemirAjans.Domain.ExtraProperties;
using System.ComponentModel.DataAnnotations;
using System;
using System.Xml.Linq;

namespace Kab.DemirAjans.Domain.SubCategories;

public class SubCategory : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [MaxLength(SubCategoryConst.MaxNameLength)]
    [Required]
    public string Name { get; protected set; }
    public Guid ImageName { get; protected set; }
    public int CategoryId { get; protected set; }
    public int Skid { get; protected set; }

    public SubCategory(string name, Guid imageName ,int categoryId, int skid)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetImageName(imageName);
        SetCategoryId(categoryId);
        SetSkid(skid);
    }

    public SubCategory(int id, string name, Guid imageName, int categoryId, int Skid)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetImageName(imageName);
        SetCategoryId(categoryId);
    }

    private void SetImageName(Guid imageName)
    {
        ImageName = imageName;
    }

    private void SetCategoryId(int categoryId)
    {
        if (categoryId < 1) throw new ArgumentException("Kategori referansı 1'den küçük olamaz!");

        CategoryId = categoryId;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Alt kategori adı boş olamaz!");
        if (name.Length > SubCategoryConst.MaxNameLength)
            throw new Exception($"Alt kategori adı {SubCategoryConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    private void SetSkid(int skid)
    {
        if (skid < 1) throw new Exception();

        Skid = skid;
    }
}