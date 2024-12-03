using Kab.DemirAjans.Domain.ExtraProperties;
using System.ComponentModel.DataAnnotations;
using System;

namespace Kab.DemirAjans.Domain.SubCategories;

public class SubCategory : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [MaxLength(SubCategoryConst.MaxNameLength)]
    [Required]
    public string Name { get; protected set; }
    public int CategoryId { get; protected set; }
    public SubCategory(string name, int categoryId)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetCategoryId(categoryId);
    }

    public SubCategory(int id, string name, int categoryId)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetCategoryId(categoryId);
    }

    private void SetCategoryId(int categoryId)
    {
        if (categoryId < 1) throw new ArgumentException("Kategori referansı 1'den küçük olamaz!");

        CategoryId = categoryId;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Alt kategori adi boş olamaz!");
        if (name.Length > SubCategoryConst.MaxNameLength)
            throw new Exception($"Alt kategori adı {SubCategoryConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }
}