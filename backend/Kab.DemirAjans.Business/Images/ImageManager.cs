using Kab.DemirAjans.Business.Helper.ImageHelper;
using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Images;
using Kab.DemirAjans.Domain.Images;
using Kab.DemirAjans.Entities.Categories;
using Kab.DemirAjans.Entities.Images;
using System;

namespace Kab.DemirAjans.Business.Images;

public class ImageManager(IImageDal imageDal) : IImageService
{
    private readonly IImageDal _imageDal = imageDal;

    public async Task<IEnumerable<ImageDto>> GetListByProductIdAsyns(int productId)
    {
        var imageList = await _imageDal.GetListByProductIdAsync(productId);

        List<Task<CategoryProductGetImageBase64Dto>> tasks = [];
        foreach (var imageDto in imageList)
        {
            tasks.Add(Task.Run(() => ImageHelper.GetImage(imageDto.Id, ImageEnum.Product)));
        }
        var results = await Task.WhenAll(tasks);

        List<Task<string>> tasks2 = [];
        foreach (var task in results)
        {
            tasks2.Add(Task.Run(() => imageList.ToList().Find(x => x.Id == task.ImageName)!.Base64 = task.Base64));
        }
        await Task.WhenAll(tasks2);

        return imageList;
    }

    public async Task InsertAsync(ImageCreateDto create, int productId)
    {
        if (string.IsNullOrEmpty(create.Base64)) return;

        var guid = await Task.Run(() => ImageHelper.SaveImage(create.Base64, ImageEnum.Product));

        if (string.IsNullOrEmpty(guid.ToString()))
            throw new ArgumentException("Fotoğraf oluşturulamadı!");

        var image = new Image(productId, create.IsFrontImage);

        var imageDto = ObjectMapper.Mapper.Map<Image, ImageDto>(image);
        imageDto.Id = guid;

        await _imageDal.InsertAsync(imageDto);
    }
}