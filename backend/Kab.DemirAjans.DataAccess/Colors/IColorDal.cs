using Kab.DemirAjans.Entities.Colors;

namespace Kab.DemirAjans.DataAccess.Colors
{
    public interface IColorDal
    {
        Task<IEnumerable<ColorDto>> GetListByProductIdAsync(int productId);
        Task InsertAsync(ColorDto colorDto);
    }
}