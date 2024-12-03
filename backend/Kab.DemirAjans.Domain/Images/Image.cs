using Kab.DemirAjans.Domain.ExtraProperties;
using System;

namespace Kab.DemirAjans.Domain.Images;

public class Image : AuditedAggregateRoot
{
    public Guid Id { get; set; }
    public bool IsFrontImage { get; set; }
    public int ProductId { get; set; }

    public Image(Guid id, bool isFrontImage, int productId)
    {
        SetDefaultExtraProperties(false);
        SetIsFrontImage(isFrontImage);
        SetProductId(productId);
    }

    public Image(bool isFrontImage, int productId)
    {
        SetDefaultExtraProperties(true);
        SetIsFrontImage(isFrontImage);
        SetProductId(productId);
    }

    public void SetIsFrontImage(bool isFrontImage)
    {
        IsFrontImage = isFrontImage;
    }

    public void SetProductId(int productId)
    {
        if (productId < 1) throw new ArgumentException("Ürün referansı 0 veya daha küçük olamaz!");

        ProductId = productId;
    }
}