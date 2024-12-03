using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Images;
using Kab.DemirAjans.Domain.Images;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Entities.Images;
using Kab.DemirAjans.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Business.Images;

public class ImageManager(IImageDal imageDal) : IImageService
{
    private readonly IImageDal _imageDal = imageDal;

    public async Task InsertAsync(ImageCreateDto create)
    {
        var guid = Guid.NewGuid();

        var image = new Image(create.ProductId, create.IsFrontImage);

        var imageDto = ObjectMapper.Mapper.Map<Image, ImageDto>(image);
        imageDto.Id = guid;

        await _imageDal.InsertAsync(imageDto);
    }
}