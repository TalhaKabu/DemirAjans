using Kab.DemirAjans.Entities.Carts;

namespace Kab.DemirAjans.Business.Carts;

public interface ICartService
{
    Task<IEnumerable<CartDto>> GetListByUserIdAsync(int userId);
    Task InsertAsync(CartCreateDto create);
}