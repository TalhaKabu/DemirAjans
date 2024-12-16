using Kab.DemirAjans.Domain.ExtraProperties;

namespace Kab.DemirAjans.Domain.Carts;

public class Cart : AuditedAggregateRoot
{
    public int Id { get; protected set; }
    public int UserId { get; protected set; }
    public int ColorId { get; protected set; }
    public int Quantity { get; protected set; }

    public Cart(int id, int userId, int colorId, int quantity)
    {
        SetDefaultExtraProperties(false);
        SetUserId(userId);
        SetProductId(colorId);
        SetQuantity(quantity);
    }

    public Cart(int userId, int colorId, int quantity)
    {
        SetDefaultExtraProperties(true);
        SetUserId(userId);
        SetProductId(colorId);
        SetQuantity(quantity);
    }

    public void SetProductId(int colorId)
    {
        if (colorId < 1)
            throw new ArgumentException("Ürün renk referansı 0 veya daha küçük daha olamaz!");

        ColorId = colorId;
    }

    public void SetUserId(int userId)
    {
        if (userId < 1)
            throw new ArgumentException("Kullanıcı referansı 0 veya daha küçük daha olamaz!");

        UserId = userId;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}