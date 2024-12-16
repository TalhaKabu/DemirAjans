using Kab.DemirAjans.Entities.Carts;

namespace Kab.DemirAjans.DataAccess.Carts;

public interface ICartDal
{
    Task<IEnumerable<CartDto>> GetListByUserIdAsync(int userId);
    Task InsertAsync(CartDto cartDto);
}