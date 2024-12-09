using Kab.DemirAjans.Entities.Colors;

namespace Kab.DemirAjans.Business.Colors
{
    public interface IColorService
    {
        Task<IEnumerable<ColorDto>> GetListByProductIdAsync(int productId);
        Task InsertAsync(ColorCreateDto create);
    }
}