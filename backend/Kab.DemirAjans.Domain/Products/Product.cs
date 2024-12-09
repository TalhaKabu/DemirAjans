using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;

namespace Kab.DemirAjans.Domain.Products;

public class Product : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [MaxLength(ProductConst.MaxNameLength)]
    [Required]
    public string Name { get; protected set; }

    public int CategoryId { get; protected set; }

    public int SubCategoryId { get; protected set; }

    [MaxLength(ProductConst.MaxCodeLength)]
    [Required]
    public string Code { get; protected set; }

    [MaxLength(ProductConst.MaxGroupCodeLength)]
    [Required]
    public string GroupCode { get; protected set; }

    public decimal Price { get; protected set; }

    public int Vat { get; protected set; }

    public int Uid { get; protected set; }

    public bool AppearInFront { get; protected set; }

    [MaxLength(ProductConst.MaxHeaderLength)]
    [Required]
    public string Header { get; protected set; }

    [MaxLength(ProductConst.MaxDimensionLength)]
    public string? Dimension { get; protected set; }

    [MaxLength(ProductConst.MaxPrintExpLength)]
    public string? PrintExp { get; protected set; }

    [MaxLength(ProductConst.MaxDescriptionLength)]
    public string? Description { get; protected set; }

    public Product(int id, string name, int categoryId, int subCategoryId, string code, string groupCode, decimal Price, bool appearInFront, string header, int vat, int uid, string? dimension, string? printExp, string? description)
    {
        SetDefaultExtraProperties(false);
        SetName(name);
        SetCategoryId(categoryId);
        SetSubCategoryId(subCategoryId);
        SetCode(code);
        SetGroupCode(groupCode);
        SetPrice(Price);
        SetDimension(dimension);
        SetAppearInFront(appearInFront);
        SetHeader(header);
        SetPrintExp(printExp);
        SetDescription(description);
        SetVat(vat);
        SetUid(uid);
    }

    public Product(string name, int categoryId, int subCategoryId, string code, string groupCode, decimal Price, bool appearInFront, string header, int vat, int uid, string? dimension, string? printExp, string? description)
    {
        SetDefaultExtraProperties(true);
        SetName(name);
        SetCategoryId(categoryId);
        SetSubCategoryId(subCategoryId);
        SetCode(code);
        SetGroupCode(groupCode);
        SetPrice(Price);
        SetDimension(dimension);
        SetAppearInFront(appearInFront);
        SetHeader(header);
        SetPrintExp(printExp);
        SetDescription(description);
        SetVat(vat);
        SetUid(uid);
    }

    private void SetUid(int uid)
    {
        Uid = uid;
    }

    private void SetVat(int vat)
    {
        Vat = vat;
    }

    private void SetDescription(string? description)
    {
        if (description.Length > ProductConst.MaxDescriptionLength)
            throw new Exception($"Ürün açıklaması {ProductConst.MaxDescriptionLength} 'ten büyük olamaz!");

        Description = description;
    }

    private void SetPrintExp(string? printExp)
    {
        if (printExp.Length > ProductConst.MaxPrintExpLength)
            throw new Exception($"Ürün baskı {ProductConst.MaxPrintExpLength} 'ten büyük olamaz!");

        PrintExp = printExp;
    }

    private void SetHeader(string header)
    {
        if (string.IsNullOrEmpty(header))
            throw new ArgumentNullException("Ürün başlıği boş olamaz!");
        if (header.Length > ProductConst.MaxHeaderLength)
            throw new Exception($"Ürün başlıği {ProductConst.MaxHeaderLength} 'ten büyük olamaz!");

        Header = header;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Ürün adi boş olamaz!");
        if (name.Length > ProductConst.MaxNameLength)
            throw new Exception($"Ürün adı {ProductConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    private void SetAppearInFront(bool appearInFront)
    {
        AppearInFront = appearInFront;
    }

    private void SetCategoryId(int categoryId)
    {
        if (categoryId < 1)
            throw new ArgumentException("Kategori referansı 0 veya daha küçük olamaz!");

        CategoryId = categoryId;
    }

    private void SetSubCategoryId(int subCategoryId)
    {
        SubCategoryId = subCategoryId;
    }

    private void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentNullException("Ürün kodu boş olamaz!");
        if (code.Length > ProductConst.MaxCodeLength)
            throw new Exception($"Ürün kodu {ProductConst.MaxCodeLength} 'ten büyük olamaz!");

        Code = code;
    }

    private void SetGroupCode(string groupCode)
    {
        if (string.IsNullOrEmpty(groupCode))
            throw new ArgumentNullException("Ürün grup kodu boş olamaz!");
        if (groupCode.Length > ProductConst.MaxGroupCodeLength)
            throw new Exception($"Ürün grup kodu {ProductConst.MaxGroupCodeLength} 'ten büyük olamaz!");

        GroupCode = groupCode;
    }

    private void SetDimension(string? dimension)
    {
        Dimension = dimension;
    }

    private void SetPrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Ürün fiyatı 0'dan küçük olamaz!");

        Price = price;
    }
}