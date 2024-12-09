using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Colors;
using Kab.DemirAjans.Domain.Colors;
using Kab.DemirAjans.Entities.Colors;

namespace Kab.DemirAjans.Business.Colors;

public class ColorManager(IColorDal colorDal) : IColorService
{
    private readonly IColorDal _colorDal = colorDal;

    public async Task<IEnumerable<ColorDto>> GetListByProductIdAsync(int productId) => await _colorDal.GetListByProductIdAsync(productId);

    public async Task InsertAsync(ColorCreateDto create)
    {
        if (string.IsNullOrEmpty(create.Base64)) throw new Exception("Renkler en az bir fotoğrafa sahip olmak zorundadır!");

        var guid = await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Product));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        try
        {
            var color = new Color(create.ProductId, create.Name, create.Code, create.Header, create.Uid, guid);

            await _colorDal.InsertAsync(ObjectMapper.Mapper.Map<Color, ColorDto>(color));
        }
        catch (Exception ex)
        {
            if (guid != Guid.Empty)
                await Task.Run(() => ImageHelper.DeleteImage(guid, ImageEnum.Product));
            throw new ArgumentException("Beklenmedik bir hata oluştu." + ex.Message);
        }
    }
}