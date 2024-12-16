using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Carts;
using System;

namespace Kab.DemirAjans.DataAccess.Carts;

public class CartDal(ISqlDataAccess db) : ICartDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<CartDto>> GetListByUserIdAsync(int userId) => await _db.LoadDataAsync<CartDto, dynamic>(storedProcedure: "spCarts_GetByUserId", new { UserId = userId });
    public async Task InsertAsync(CartDto cartDto) => await _db.SaveDataAsync(storedProcedure: "spCarts_Insert", new { cartDto.UserId, cartDto.ProductId, cartDto.Quantity, cartDto.CreationDate, cartDto.LastModificationDate });
}