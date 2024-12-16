using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Carts;
using Kab.DemirAjans.Domain.Carts;
using Kab.DemirAjans.Entities.Carts;

namespace Kab.DemirAjans.Business.Carts;

public class CartManager(ICartDal cartDal) : ICartService
{
    private ICartDal _cartDal = cartDal;

    public async Task<IEnumerable<CartDto>> GetListByUserIdAsync(int userId) => await _cartDal.GetListByUserIdAsync(userId);

    public async Task InsertAsync(CartCreateDto create)
    {
        var cart = new Cart(create.UserId, create.ColorId, create.Quantity);

        await _cartDal.InsertAsync(ObjectMapper.Mapper.Map<Cart, CartDto>(cart));
    }
}