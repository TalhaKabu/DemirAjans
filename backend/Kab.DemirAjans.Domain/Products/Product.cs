using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;
using System;

namespace Kab.DemirAjans.Domain.Products;

public class Product : AuditedAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(ProductConst.MaxNameLength)]
    [Required]
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    [MaxLength(ProductConst.MaxCodeLength)]
    [Required]
    public string Code { get; set; }
    public decimal Price { get; set; }

    [MaxLength(ProductConst.MaxDimensionLength)]
    public string? Dimension { get; set; }

    public Product(int id, string name, int categoryId, int subCategoryId, string code, decimal Price, string? dimension)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetCategoryId(categoryId);
        SetSubCategoryId(subCategoryId);
        SetCode(code);
        SetPrice(Price);
        SetDimension(dimension);
    }

    public Product(string name, int categoryId, int subCategoryId, string code, decimal Price, string? dimension)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetCategoryId(categoryId);
        SetSubCategoryId(subCategoryId);
        SetCode(code);
        SetPrice(Price);
        SetDimension(dimension);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Ürün adi boş olamaz!");
        if (name.Length > ProductConst.MaxNameLength)
            throw new Exception($"Ürün adı {ProductConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    public void SetCategoryId(int categoryId)
    {
        if (categoryId < 1)
            throw new ArgumentException("Kategori referansı 0 veya daha küçük olamaz!");

        CategoryId = categoryId;
    }

    public void SetSubCategoryId(int subCategoryId)
    {
        SubCategoryId = subCategoryId;
    }

    public void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentNullException("Ürün kodu boş olamaz!");
        if (code.Length > ProductConst.MaxCodeLength)
            throw new Exception($"Ürün kodu {ProductConst.MaxCodeLength} 'ten büyük olamaz!");

        Code = code;
    }

    public void SetDimension(string? dimension)
    {
        Dimension = dimension;
    }

    public void SetPrice(decimal price)
    {
        if (price < 1)
            throw new ArgumentException("Ürün fiyatı 0 veya daha küçük olamaz!");

        Price = price;
    }
}