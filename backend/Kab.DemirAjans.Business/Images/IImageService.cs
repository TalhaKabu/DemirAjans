using Kab.DemirAjans.Entities.Images;

namespace Kab.DemirAjans.Business.Images;

public interface IImageService
{
    Task InsertAsync(ImageCreateDto create, int productId);
}