using Kab.DemirAjans.Entities.ExtraProperties;

namespace Kab.DemirAjans.Entities.Carts;

public class CartDto : AggregateRoot
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ColorId { get; set; }
    public int Quantity { get; set; }
}