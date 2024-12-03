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
    public int CategoryId { get; protected set; }

    [MaxLength(SubCategoryConst.MaxCodeLength)]
    [Required]
    public string Code { get; protected set; }
    public SubCategory(string name, int categoryId, string code)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetCategoryId(categoryId);
        SetCode(code);
    }

    public SubCategory(int id, string name, int categoryId, string code)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetCategoryId(categoryId);
        SetCode(code);
    }

    private void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentNullException("Alt kategori kodu boş olamaz!");
        if (code.Length > SubCategoryConst.MaxCodeLength)
            throw new Exception($"Alt kategori kodu {SubCategoryConst.MaxCodeLength} 'ten büyük olamaz!");

        Code = code;
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
}