using Kab.DemirAjans.Domain.ExtraProperties;

namespace Kab.DemirAjans.Domain.Carts;

public class Cart : AuditedAggregateRoot
{
    public int Id { get; protected set; }
    public int UserId { get; protected set; }
    public int ProductId { get; protected set; }
    public int Quantity { get; protected set; }

    public Cart(int id, int userId, int productId, int quantity)
    {
        SetDefaultExtraProperties(false);
        SetUserId(userId);
        SetProductId(productId);
        SetQuantity(quantity);
    }

    public Cart(int userId, int productId, int quantity)
    {
        SetDefaultExtraProperties(true);
        SetUserId(userId);
        SetProductId(productId);
        SetQuantity(quantity);
    }

    public void SetProductId(int productId)
    {
        if (productId < 1)
            throw new ArgumentException("Ürün referansı 0 veya daha küçük daha olamaz!");

        ProductId = productId;
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