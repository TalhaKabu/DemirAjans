using Kab.DemirAjans.Domain.ExtraProperties;
using System.ComponentModel.DataAnnotations;

namespace Kab.DemirAjans.Domain.Colors;

public class Color : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [Required]
    [MaxLength(ColorConst.MaxNameLength)]
    public string Name { get; protected set; }

    [Required]
    [MaxLength(ColorConst.MaxCodeLength)]
    public string Code { get; protected set; }

    [Required]
    public int ProductId { get; protected set; }

    [Required]
    public int Uid { get; protected set; }

    [Required]
    public Guid ImageName { get; protected set; }

    public Color(int id, int productId, string name, string code, int uid, Guid imageName)
    {
        SetDefaultExtraProperties(false);
        SetProductId(productId);
        SetName(name);
        SetCode(code);
        SetUid(uid);
        SetImageName(imageName);
    }

    public Color(int productId, string name, string code, int uid, Guid imageName)
    {
        SetDefaultExtraProperties(true);
        SetProductId(productId);
        SetName(name);
        SetCode(code);
        SetUid(uid);
        SetImageName(imageName);
    }

    private void SetProductId(int productId)
    {
        if (productId < 1)
            throw new ArgumentException("Ürün referansı 1'den küçük olamaz!");

        ProductId = productId;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Renk adı boş olamaz!");
        if (name.Length > ColorConst.MaxNameLength)
            throw new Exception($"Renk adı {ColorConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    private void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentNullException("Renk kodu boş olamaz!");
        if (code.Length > ColorConst.MaxCodeLength)
            throw new Exception($"Renk kodu {ColorConst.MaxCodeLength} 'ten büyük olamaz!");

        Code = code;
    }

    private void SetUid(int uid)
    {
        Uid = uid;
    }

    private void SetImageName(Guid imageName)
    {
        ImageName = imageName;
    }
}