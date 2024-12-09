using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Colors;

namespace Kab.DemirAjans.DataAccess.Colors;

public class ColorDal(ISqlDataAccess db) : IColorDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<ColorDto>> GetListByProductIdAsync(int productId) => await _db.LoadDataAsync<ColorDto, dynamic>(storedProcedure: "spColors_GetByProductId", new { ProductId = productId });
    public async Task InsertAsync(ColorDto colorDto) => await _db.SaveDataAsync(storedProcedure: "spColors_Insert", new { colorDto.Name, colorDto.Code, colorDto.Header, colorDto.ProductId, colorDto.Uid, colorDto.ImageName, colorDto.LastModificationDate, colorDto.CreationDate });
}