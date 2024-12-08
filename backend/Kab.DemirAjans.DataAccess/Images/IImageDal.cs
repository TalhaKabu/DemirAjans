using Kab.DemirAjans.Entities.Images;

namespace Kab.DemirAjans.DataAccess.Images;

public interface IImageDal
{
    Task InsertAsync(ImageDto imageDto);
    Task<IEnumerable<ImageDto>> GetListByProductIdAsync(int productId);
}